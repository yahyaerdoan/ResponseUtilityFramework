# ResponseResultHandler

A Result-Pattern library for .NET (net6.0–net10.0, netstandard2.0). Wraps the outcome of an
operation — success or failure, an HTTP-mappable status, a title/detail, and optional data — in an
immutable object instead of throwing exceptions or returning bare booleans.

```
dotnet add package ResponseResultHandler
dotnet add package ResponseResultHandler.AspNetCore   # optional: IActionResult / RFC 9457 adapter
```

Everything below is demonstrated through one running example: a `ProductService` that looks up a
product by id, and a `ProductsController` that exposes it over HTTP.

---
## 1. The core contract

Every result implements `IResult` (`ResultHandler.Core.Abstractions`):

| Member | Meaning |
|---|---|
| `bool IsSuccessful` | did the operation succeed |
| `ResultStatus Status` | outcome status — an enum, not `HttpStatusCode`, see §2 |
| `string Title` | short summary, e.g. `"Not found."` |
| `string? Detail` | optional extra context, e.g. `"Product 42 does not exist."` |
| `IReadOnlyList<string> Errors` | optional list of individual error messages (validation, etc.) |

`IDataResult<T> : IResult` adds `T Data` — guaranteed non-null when `IsSuccessful` is `true`
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

public IDataResult<ProductDto> GetById(int id)
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
    return new ErrorResult("Validation failed.", ResultStatus.Invalid,
        new[] { "Name is required.", "Price must be greater than zero." });
}
```

`Result` / `DataResult<T>` (`ResultHandler.Core.Base`) are the base classes both of the above
inherit from — construct them directly only for a custom result shape that isn't a plain
success/error; `SuccessResult`/`ErrorResult` cover the normal cases.

---
## 4. The `Results` facade — the recommended way

`ResultHandler.Results` is a static class with one factory pair per `ResultStatus` (non-generic and
`<T>`), named after the status, with sensible default titles baked in. It's what the example above
looks like using it instead:

```csharp
using ResultHandler; // Results

public IDataResult<ProductDto> GetById(int id)
{
    var product = _products.Find(id);

    return product is null
        ? Results.NotFound<ProductDto>($"Product {id} does not exist.")
        : Results.Success(ToDto(product), "Product found.");
}

public ErrorResult ValidateCreate(CreateProductRequest request)
{
    var errors = new List<string>();
    if (string.IsNullOrEmpty(request.Name)) errors.Add("Name is required.");
    if (request.Price <= 0) errors.Add("Price must be greater than zero.");

    return errors.Count > 0 ? Results.Invalid(errors.ToArray()) : null!;
}

public SuccessResult MoveResource(int id, string newLocation)
    => Results.MovedPermanently(newLocation); // 3xx redirects — location gets interpolated into the title

// Escape hatch for anything not covered by a named factory:
public ErrorResult CustomFailure()
    => Results.Failure("Payment declined.", "The card was rejected by the issuer.", ResultStatus.PaymentRequired);
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

        return Results.Created(_products.Create(request)).ToActionResult();
    }
}
```

* **`ToActionResult()`** — success returns the raw payload (`200 { ... }`), or a bodyless status for
  `NoContent`/1xx/3xx; failure returns an RFC 9457 `ProblemDetails` body.
* **`ToEnvelopedActionResult()`** — success returns the *whole* result object (status/title/data) as
  the body instead of just the payload — useful when clients want metadata alongside the data.
* **`ToProblemDetails(HttpContext? httpContext = null)`** — builds the `ProblemDetails` yourself;
  pass `HttpContext` and `Instance` gets set to the current request path (RFC 9457 §3.1.4).
* Every 4xx/5xx `ResultStatus` maps `ProblemDetails.Type` to the actual RFC section that defines it
  (RFC 9110, RFC 6585, RFC 4918, RFC 7725, RFC 8470); 1xx/2xx/3xx use `about:blank` per RFC 9457
  §4.2.1, since those aren't "problems".

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

`ToActionResult()` returns `Microsoft.AspNetCore.Mvc.IActionResult`, and Minimal API endpoint
delegates accept `IActionResult` return values natively — no separate adapter needed:

```csharp
using ResultHandler.AspNetCore.Extensions;

var app = WebApplication.Create(args);
app.Services.GetRequiredService<IServiceCollection>(); // ...DI setup omitted

app.MapGet("/api/products/{id:int}", (int id, ProductService products, HttpContext httpContext)
    => products.GetById(id).ToActionResult(httpContext));

app.MapPost("/api/products", (CreateProductRequest request, ProductService products) =>
{
    var validation = products.ValidateCreate(request);
    return validation is not null
        ? validation.ToActionResult()
        : ResultHandler.Results.Created(products.Create(request)).ToActionResult();
});

app.Run();
```

> **Naming collision to watch for:** ASP.NET Core's own Minimal API helpers live in
> `Microsoft.AspNetCore.Http` as a static class also named `Results` (`Results.Ok(...)`,
> `Results.NotFound()`), and its endpoint delegates return an interface also named `IResult`. If a
> file has `using Microsoft.AspNetCore.Http;` alongside `using ResultHandler;`, both `Results` and
> `IResult` become ambiguous. Fully qualify this library's facade as `ResultHandler.Results.X(...)`
> in files that also use ASP.NET Core's built-in helpers (as above), or keep the two usages in
> separate files — don't try to alias one away, since `ToActionResult()` already returns the MVC
> `IActionResult` that both minimal endpoints and controllers understand, so you rarely need
> ASP.NET Core's own `Results`/`IResult` at all once you're using this library.

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

IDataResult<OrderDto> order = _products.GetById(id)
    .Bind(product => _orders.CreateDraftOrder(product)); // chains into another IDataResult<T>-returning call
```

`Map`/`Bind` short-circuit automatically: if the source result failed, the mapper/binder never runs
and the failure (title/status/detail/errors) is carried over into the new result type.

---
## 8. Serialization

`System.Text.Json` output uses fixed property names regardless of your `JsonSerializerOptions`
naming policy, and `ResultStatus` always serializes as its numeric HTTP code:

```csharp
JsonSerializer.Serialize(Results.NotFound<ProductDto>("Product 42 does not exist."));
```

```json
{
  "IsSuccessful": false,
  "statusCode": 404,
  "statusMessage": "Not found.",
  "detail": "Product 42 does not exist.",
  "resultData": null
}
```

`Detail` is omitted entirely when `null`. Obsolete members (`StatusMessage`, `StatusCode`,
`ResultData`) never appear in JSON — only the current API does.

---
## 9. Equality & debugging

`Result`/`DataResult<T>` override `Equals`/`GetHashCode` (structural, by value) and `ToString()`:

```csharp
Results.NotFound("x") == Results.NotFound("x"); // false (reference types) — use .Equals()
Results.NotFound("x").Equals(Results.NotFound("x")); // true
Results.NotFound("x").ToString(); // "NotFound (404): Not found."
```

---
## 10. Migrating from the pre-v11 API

`StatusMessage`, `StatusCode: HttpStatusCode`, and `ResultData` still work — marked `[Obsolete]` so
existing code keeps compiling while you migrate to `Title`, `Status: ResultStatus`, and `Data`:

```csharp
#pragma warning disable CS0618
var legacy = new ErrorResult("Not found.", HttpStatusCode.NotFound); // forwards into the new API
Console.WriteLine(legacy.StatusMessage); // "Not found." — same as legacy.Title
#pragma warning restore CS0618
```
