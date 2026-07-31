# ResponseResultHandler

A Result-Pattern library for .NET (net7.0–net10.0). Wraps the outcome of an
operation — success or failure, an HTTP-mappable status, a title/detail, and optional data — in an
immutable object instead of throwing exceptions or returning bare booleans.

This repository is two NuGet packages sharing this README:

| Package | Project | Purpose |
|---|---|---|
| [`ResponseResultHandler`](https://www.nuget.org/packages/ResponseResultHandler) | `src/ResultHandler` | Core library — framework-agnostic |
| [`ResponseResultHandler.AspNetCore`](https://www.nuget.org/packages/ResponseResultHandler.AspNetCore) | `src/ResultHandler.AspNetCore` | Converts results to `IActionResult` / RFC 9457 Problem Details |

```
dotnet add package ResponseResultHandler
dotnet add package ResponseResultHandler.AspNetCore   # optional: IActionResult / RFC 9457 adapter
```

Everything below is demonstrated through one running example: a `ProductService` that looks up a
product by id, and a `ProductsController` that exposes it over HTTP.

---
## 1. The core contract

Every result implements `IOperationResult` (`ResultHandler.Core.Abstractions`):

| Member | Meaning |
|---|---|
| `bool IsSuccessful` | did the operation succeed |
| `ResultStatus Status` | outcome status — an enum, not `HttpStatusCode`, see §2 |
| `string Title` | short summary, e.g. `"Not found."` |
| `string? Detail` | optional extra context, e.g. `"Product 42 does not exist."` |
| `IReadOnlyList<string> Errors` | optional list of individual error messages (validation, etc.) |

`IOperationResult<T> : IOperationResult` adds `T Data` — guaranteed non-null when `IsSuccessful` is `true`
(the compiler enforces this via `[MemberNotNullWhen]`, so `result.Data` is safe to use right after
an `if (result.IsSuccessful)` check without a null-forgiving operator).

---
## 2. `ResultStatus`

An enum covering every standard 1xx–5xx HTTP status (`ResultHandler.Core.Enums`), kept independent
of `System.Net.HttpStatusCode` so the library has no hard dependency on ASP.NET Core. Convert either
direction with the extension methods in `ResultHandler.Mapping`:

```csharp
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;

HttpStatusCode code = ResultStatus.NotFound.ToHttpStatusCode();   // 404
ResultStatus status = HttpStatusCode.Conflict.ToResultStatus();  // Conflict
```

---
## 3. Building results directly

`SuccessResult` / `SuccessDataResult<T>` and `ErrorResult` / `ErrorDataResult<T>`
(`ResultHandler.Implementations.Success` / `.Error`) pin `IsSuccessful` for you:

```csharp
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;

public IOperationResult<ProductDto> GetById(int id)
{
    var product = _products.Find(id);

    if (product is null)
    {
        return new ErrorDataResult<ProductDto>(
            "Not found.", ResultStatus.NotFound, $"Product {id} does not exist.");
    }

    return new SuccessDataResult<ProductDto>(ToDto(product), "Product found.", ResultStatus.Ok);
}
```

Validation errors use the `IReadOnlyList<string> errors` overload instead of `detail`:

```csharp
if (request.Name is { Length: 0 })
{
    return new ErrorResult("Validation failed.", ResultStatus.UnprocessableContent,
        new[] { "Name is required.", "Price must be greater than zero." });
}
```

`OperationResult` / `OperationDataResult<T>` (`ResultHandler.Core.Base`) are the base classes both of
the above inherit from — construct them directly only for a custom result shape that isn't a plain
success/error; `SuccessResult`/`ErrorResult` cover the normal cases.

---
## 4. The `Result` facade — the recommended way

`ResultHandler.Facade.Result` is a static class with one factory pair per `ResultStatus`
(non-generic and `<T>`), named after the status, with sensible default titles baked in. It's what
the example above looks like using it instead:

```csharp
using ResultHandler.Facade; // Result

public IOperationResult<ProductDto> GetById(int id)
{
    var product = _products.Find(id);

    return product is null
        ? Result.NotFound<ProductDto>($"Product {id} does not exist.")
        : Result.Success(ToDto(product), "Product found.");
}

public ErrorResult ValidateCreate(CreateProductRequest request)
{
    var errors = new List<string>();
    if (string.IsNullOrEmpty(request.Name)) errors.Add("Name is required.");
    if (request.Price <= 0) errors.Add("Price must be greater than zero.");

    return errors.Count > 0 ? Result.Invalid(errors.ToArray()) : null!;
}

public SuccessResult MoveResource(int id, string newLocation)
    => Result.MovedPermanently(newLocation); // 3xx redirects — location gets interpolated into the title

// Escape hatch for anything not covered by a named factory:
public ErrorResult CustomFailure()
    => Result.Failure("Payment declined.", "The card was rejected by the issuer.", ResultStatus.PaymentRequired);
```

---
## 5. `ResultHandler.AspNetCore` — converting to `IActionResult`

Add the `ResponseResultHandler.AspNetCore` package and call one extension method
(`ResultHandler.AspNetCore.Extensions`) at the end of a controller action:

```csharp
using ResultHandler.AspNetCore.Extensions;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _products;

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
        => _products.GetById(id).ToActionResult(HttpContext);

    [HttpPost]
    public IActionResult Create(CreateProductRequest request)
    {
        var validation = _products.ValidateCreate(request);
        if (validation is not null)
        {
            return validation.ToActionResult(); // 422 Problem Details with the two validation errors
        }

        return Result.Created(_products.Create(request)).ToActionResult();
    }
}
```

* **`ToActionResult()`** — success returns the raw payload with the result's actual status code
  (`201 { ... }` for `Created`, `202 { ... }` for `Accepted`, etc. — not hardcoded to `200`), or a
  bodyless status for `NoContent`/1xx/3xx; failure returns an RFC 9457 `ProblemDetails` body.
* **`ToEnvelopedActionResult()`** — success returns the *whole* result object (status/title/data) as
  the body instead of just the payload, with the same status-code-preserving behavior — useful when
  clients want metadata alongside the data.
* **`ToProblemDetails(HttpContext? httpContext = null)`** — builds the `ProblemDetails` yourself;
  pass `HttpContext` and `Instance` gets set to the current request path (RFC 9457 §3.1.4).
* Every 4xx/5xx `ResultStatus` maps `ProblemDetails.Type` to the actual RFC section that defines it
  (RFC 9110, RFC 6585, RFC 4918, RFC 7725, RFC 8470); 1xx/2xx/3xx use `about:blank` per RFC 9457
  §4.2.1, since those aren't "problems".
* These `IActionResult`-returning methods are for **MVC controllers**. In a Minimal API endpoint
  delegate, use the `IResult`-returning siblings from §6 instead — returning `IActionResult` from a
  delegate triggers analyzer warning `ASP0004` and hides the response shape from OpenAPI/Swagger
  generation at compile time.

A failed `GetById(999)` call above produces:

```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Not found.",
  "status": 404,
  "detail": "Product 999 does not exist.",
  "instance": "/api/products/999"
}
```

---
## 6. Minimal APIs

Minimal API endpoint delegates *can* return `IActionResult` — ASP.NET Core has run it through an MVC
compatibility shim since .NET 7 — but don't. That path triggers analyzer warning `ASP0004` and, more
importantly, `IActionResult` is opaque to the endpoint metadata pipeline: the compile-time
`IEndpointMetadataProvider` machinery that Swashbuckle/`Microsoft.AspNetCore.OpenApi` rely on to infer
response types and status codes can't see through it, so your OpenAPI/Swagger document ends up
missing or wrong for those endpoints.

Use the `IResult`-returning siblings instead — same shapes, same status-code-preserving behavior, but
native to Minimal APIs and fully visible to OpenAPI generation:

* **`ToResult(HttpContext? httpContext = null)`** — `IOperationResult` → `IResult`. Success returns a
  bodyless status (`204` for `NoContent`, `304` for `NotModified`, plain status code for 1xx/3xx/`Ok`);
  failure returns an RFC 9457 `ProblemDetails` JSON body via `ToProblemResult`.
* **`ToResult<T>(HttpContext? httpContext = null)`** — `IOperationResult<T>` → `IResult`. Success
  returns the raw payload as JSON with the result's actual status code (`201` for `Created`, `202` for
  `Accepted`, etc.); failure is the same `ProblemDetails` JSON body.
* **`ToEnvelopedResult(HttpContext? httpContext = null)`** — success returns the *whole* result object
  (status/title/data) as the JSON body instead of just the payload.
* **`ToProblemResult(HttpContext? httpContext = null)`** — maps a failed result straight to an
  `IResult` carrying RFC 9457 `ProblemDetails` JSON; the same building block `ToResult`/`ToResult<T>`/
  `ToEnvelopedResult` use internally for their failure branch.

```csharp
using ResultHandler.AspNetCore.Extensions;
using ResultHandler.Facade; // Result

var app = WebApplication.Create(args);
app.Services.GetRequiredService<IServiceCollection>(); // ...DI setup omitted

app.MapGet("/api/products/{id:int}", (int id, ProductService products, HttpContext httpContext)
    => products.GetById(id).ToResult(httpContext));

app.MapPost("/api/products", (CreateProductRequest request, ProductService products) =>
{
    var validation = products.ValidateCreate(request);
    return validation is not null
        ? validation.ToProblemResult() // 422 Problem Details with the two validation errors
        : Result.Created(products.Create(request)).ToResult();
});

app.Run();
```

---
## 7. Functional composition

`ResultHandler.Functional` adds chaining helpers so callers don't have to repeat
`if (!result.IsSuccessful) return ...` at every step:

```csharp
using ResultHandler.Functional;

string message = _products.GetById(id)
    .Map(p => p.Name.ToUpperInvariant())
    .Match(
        onSuccess: name => $"Found: {name}",
        onFailure: failure => $"Error: {failure.Title}");

_products.GetById(id)
    .OnSuccess(product => _logger.LogInformation("Fetched {Name}", product.Name)) // typed: product is ProductDto
    .OnFailure(failure => _logger.LogWarning("Lookup failed: {Title}", failure.Title));

IOperationResult<OrderDto> order = _products.GetById(id)
    .Bind(product => _orders.CreateDraftOrder(product)); // chains into another IOperationResult<T>-returning call
```

`Map`/`Bind` short-circuit automatically: if the source result failed, the mapper/binder never runs
and the failure (title/status/detail/errors) is carried over into the new result type.

---
## 8. Generic short-circuiting — `IResultFailureFactory<TSelf>` / `ResultFailureFactory`

Everything above assumes the calling code knows the concrete result type (`IOperationResult<ProductDto>`,
`ErrorResult`, ...). Generic infrastructure often doesn't — a MediatR `IPipelineBehavior<TRequest, TResponse>`,
a gRPC interceptor, any short-circuiting middleware only has `TResponse` as a type parameter. Today that
usually gets solved by throwing an exception to unwind the pipeline, because you can't `new TResponse(...)`
without knowing what `TResponse` actually is.

`IResultFailureFactory<TSelf>` (`ResultHandler.Core.Abstractions`) solves this with a C# 11 static-abstract-interface
CRTP: it lets `TSelf` build its own failure instance. `OperationResult` and `OperationDataResult<T>` already
implement it, so **any** result type built on top of this library (concrete or still generic) gets it for free:

```csharp
public interface IResultFailureFactory<TSelf> where TSelf : IOperationResult
{
    static abstract TSelf Failure(IReadOnlyList<string> errors);               // validation message list
    static abstract TSelf Failure(string title, string detail, ResultStatus status); // everything else
}
```

`ResultFailureFactory` (`ResultHandler.Functional`) layers the same named, per-status vocabulary as `Result` on top
of these two primitives — `BadRequest`, `NotFound`, `Unauthorized`, `Forbidden`, and every other 4xx/5xx —
generically, for any `TSelf`. It delegates to the matching `Result.XXX(detail)` method internally, so titles
and default messages have exactly one source of truth (`Result`); nothing is duplicated.

A MediatR pipeline behavior that stops throwing and starts returning:

```csharp
using ResultHandler.Core.Abstractions;
using ResultHandler.Functional;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IOperationResult, IResultFailureFactory<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        var errors = validators
            .Select(v => v.Validate(request))
            .SelectMany(r => r.Errors)
            .Select(f => f.ErrorMessage)
            .ToArray();

        if (errors.Length > 0)
        {
            return TResponse.Failure(errors); // short-circuits the pipeline — no throw, no exception cost
        }

        return await next(ct);
    }
}

public class AuthorizationBehavior<TRequest, TResponse>(ICurrentUser user)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IRequireRole
    where TResponse : IOperationResult, IResultFailureFactory<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        if (!user.IsAuthenticated)
        {
            return ResultFailureFactory.Unauthorized<TResponse>();
        }

        if (!user.IsInRole(request.RequiredRole))
        {
            return ResultFailureFactory.Forbidden<TResponse>();
        }

        return await next(ct);
    }
}
```

For this to type-check, the command/query itself declares its response as an `OperationDataResult<T>` (or
any other `IResultFailureFactory` implementer) instead of a bare DTO:

```csharp
public record CreateProductCommand(string Name, decimal Price) : IRequest<OperationDataResult<ProductDto>>;

public class CreateProductHandler(IProductRepository repository)
    : IRequestHandler<CreateProductCommand, OperationDataResult<ProductDto>>
{
    public async Task<OperationDataResult<ProductDto>> Handle(CreateProductCommand request, CancellationToken ct)
    {
        if (await repository.ExistsByName(request.Name))
        {
            // built by a business-rule check that only knows IOperationResult, not the final DTO shape:
            var duplicate = ResultFailureFactory.Conflict<OperationResult>($"A product named '{request.Name}' already exists.");
            return duplicate.ToErrorDataResult<ProductDto>(); // re-projects into the handler's actual return type
        }

        var product = await repository.Add(request.Name, request.Price);
        return Result.Success(ToDto(product));
    }
}
```

`ToErrorDataResult<T>()` (`ResultHandler.Functional`) is the companion piece: it re-projects an *existing*
failed `IOperationResult` (title/status/detail/errors already decided elsewhere, e.g. in a business-rule
method) into the `ErrorDataResult<T>` shape a handler must return — a conversion, not a new factory call,
which is why it reads as `failure.ToErrorDataResult<T>()` rather than `Result.ToErrorDataResult<T>(failure)`.

The controller/endpoint at the edge doesn't change at all — `result.ToActionResult()` still works, because
`OperationDataResult<T>` still implements `IOperationResult<T>`:

```csharp
[HttpPost]
public async Task<IActionResult> Create(CreateProductCommand command)
    => (await mediator.Send(command)).ToActionResult();
```

---
## 9. Serialization

`System.Text.Json` output uses fixed property names regardless of your `JsonSerializerOptions`
naming policy, and `ResultStatus` always serializes as its numeric HTTP code:

```csharp
JsonSerializer.Serialize(Result.NotFound<ProductDto>("Product 42 does not exist."));
```

```json
{
  "isSuccessful": false,
  "statusCode": 404,
  "statusMessage": "Not found.",
  "detail": "Product 42 does not exist.",
  "resultData": null
}
```

`Detail` is omitted entirely when `null`. Obsolete members (`StatusMessage`, `StatusCode`,
`ResultData`) never appear in JSON — only the current API does.

---
## 10. Equality & debugging

`OperationResult`/`OperationDataResult<T>` override `Equals`/`GetHashCode` (structural, by value) and `ToString()`:

```csharp
Result.NotFound("x") == Result.NotFound("x"); // false (reference types) — use .Equals()
Result.NotFound("x").Equals(Result.NotFound("x")); // true
Result.NotFound("x").ToString(); // "NotFound (404): Not found."
```

---
## 11. Migrating from the pre-v11 API

`StatusMessage`, `StatusCode: HttpStatusCode`, and `ResultData` still work — marked `[Obsolete]` so
existing code keeps compiling while you migrate to `Title`, `Status: ResultStatus`, and `Data`:

```csharp
#pragma warning disable CS0618
var legacy = new ErrorResult("Not found.", HttpStatusCode.NotFound); // forwards into the new API
Console.WriteLine(legacy.StatusMessage); // "Not found." — same as legacy.Title
#pragma warning restore CS0618
```

**`ResultHandler.AspNetCore` behavior fix:** `ToActionResult<T>()` and `ToEnvelopedActionResult()`
used to hardcode a `200` status code for any successful result that carried a body, silently
discarding the result's actual `Status` (so `Result.Created(...)` came back as `200`, not `201`).
Both now honor `Status` correctly. If you were relying on the old (incorrect) `200`-always behavior,
check call sites that use non-`Ok` success statuses with `ToActionResult<T>`/`ToEnvelopedActionResult`.
