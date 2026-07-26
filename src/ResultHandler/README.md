# Documentation: Result Handling Classes and Interfaces

## Overview
This library standardizes the structure of responses across an application, particularly for
operations that return data, success/failure status, messages, and HTTP status codes. It is
built around a framework-agnostic `ResultStatus` enum (decoupled from `System.Net.HttpStatusCode`)
that maps cleanly to HTTP status codes and, via `ResultHandler.AspNetCore`, to RFC 9457 Problem
Details responses.

> **Migrating from an older version?** The previous API (`StatusMessage`, `StatusCode: HttpStatusCode`,
> `ResultData`) is still available but marked `[Obsolete]`. Prefer `Title`, `Status: ResultStatus`,
> and `Data` in new code.

---
### 1. `IResult` Interface
The base contract for all result types.

**Properties:**
* `bool IsSuccessful` — whether the operation was successful.
* `ResultStatus Status` — the outcome status, mappable to an HTTP status code.
* `string Title` — a short summary of the result.
* `string? Detail` — optional additional context.
* `IReadOnlyList<string> Errors` — optional list of error messages.
* `[Obsolete] string StatusMessage` — use `Title` instead.
* `[Obsolete] HttpStatusCode StatusCode` — use `Status` instead.

---
### 2. `IDataResult<T>` Interface
Extends `IResult` with a data payload.

**Properties:**
* `T? Data` — the data returned by the operation.
* `[Obsolete] T? ResultData` — use `Data` instead.

---
### 3. `Result` Class
Implements `IResult`.

```csharp
var result = new Result(true, ResultStatus.Ok, "Operation completed successfully.");
Console.WriteLine(result.IsSuccessful); // true
Console.WriteLine(result.Title);        // Operation completed successfully.
Console.WriteLine(result.Status);       // Ok
```

---
### 4. `DataResult<T>` Class
Extends `Result` and implements `IDataResult<T>`.

```csharp
var dataResult = new DataResult<int>(42, true, ResultStatus.Ok, "Data retrieved successfully.");
Console.WriteLine(dataResult.Data);  // 42
Console.WriteLine(dataResult.Title); // Data retrieved successfully.
```

---
### 5. `SuccessResult` / `SuccessDataResult<T>`
Represent successful outcomes; `IsSuccessful` is always `true`.

```csharp
var success = new SuccessResult("Operation succeeded.");
var successWithData = new SuccessDataResult<string>("Product Data", "Product retrieved successfully.", ResultStatus.Ok);
```

---
### 6. `ErrorResult` / `ErrorDataResult<T>`
Represent failed outcomes; `IsSuccessful` is always `false`.

```csharp
var error = new ErrorResult("Product not found.", ResultStatus.NotFound);
var errorWithErrors = new ErrorResult("Validation failed.", ResultStatus.Invalid, new[] { "Name is required." });
```

---
### 7. `Results` Static Facade
A convenience facade with a factory per `ResultStatus`, for both non-generic and generic results:

```csharp
Results.Success();
Results.Success(data);
Results.NotFound("The user does not exist.");
Results.NotFound<UserDto>("The user does not exist.");
Results.MovedPermanently("https://example.com/new-path");
Results.Failure("Custom title", "Custom detail", ResultStatus.Conflict);
```

---
### 8. `ResultHandler.AspNetCore`
Converts results directly into ASP.NET Core `IActionResult`s, including RFC 9457 Problem Details
for failures:

```csharp
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    IDataResult<UserDto> result = _userService.GetById(id);
    return result.ToActionResult();
}
```

* `ToActionResult()` / `ToActionResult<T>()` — success returns the raw data (or a bodyless status
  code for `NoContent`/1xx/3xx); failure returns a `ProblemDetails` payload.
* `ToEnvelopedActionResult()` — success returns the whole result object (metadata + data) as the body.
* `ToProblemDetails()` — builds an RFC 9457 `ProblemDetails` from a failed result.

### Conclusion
This system standardizes success and error handling — with status codes, messages, and optional
data — across the layers of an application, particularly RESTful APIs.
