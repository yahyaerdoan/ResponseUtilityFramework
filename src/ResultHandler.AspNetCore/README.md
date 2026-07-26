# ResponseResultHandler.AspNetCore

ASP.NET Core integration for [`ResponseResultHandler`](https://www.nuget.org/packages/ResponseResultHandler) —
converts `IResult`/`IDataResult<T>` into `IActionResult`, with RFC 9457 Problem Details for failures.

## Usage

```csharp
[HttpGet("{id}")]
public IActionResult Get(int id)
{
    IDataResult<UserDto> result = _userService.GetById(id);
    return result.ToActionResult();
}
```

* `ToActionResult()` / `ToActionResult<T>()` — success returns the raw data (or a bodyless status
  code for `NoContent`/1xx/3xx); failure returns an RFC 9457 `ProblemDetails` payload.
* `ToEnvelopedActionResult()` — success returns the whole result object (metadata + data) as the body.
* `ToProblemDetails(HttpContext? httpContext = null)` — builds a `ProblemDetails` from a failed
  result; pass the current `HttpContext` to populate `ProblemDetails.Instance` with the request path.

## Problem type URIs

Every 4xx/5xx `ResultStatus` maps to a canonical RFC section URI in `ProblemDetails.Type`
(RFC 9110, RFC 6585, RFC 4918, RFC 7725, RFC 8470, etc.). 1xx/2xx/3xx statuses use `about:blank`
per RFC 9457 §4.2.1, since informational/success/redirect responses don't need a problem type.
