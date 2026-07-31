using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;

namespace ResultHandler.Facade;

public static partial class Result
{
    public static ErrorResult BadRequest(string detail)
        => new("Bad Request", ResultStatus.BadRequest, detail);

    public static ErrorResult Unauthorized(string detail = FailureMessages.Unauthorized)
        => new("Unauthorized", ResultStatus.Unauthorized, detail);

    public static ErrorResult PaymentRequired(string detail)
        => new("Payment Required", ResultStatus.PaymentRequired, detail);

    public static ErrorResult Forbidden(string detail = FailureMessages.Forbidden)
        => new("Forbidden", ResultStatus.Forbidden, detail);

    public static ErrorResult NotFound(string detail)
        => new("Not Found", ResultStatus.NotFound, detail);

    public static ErrorResult MethodNotAllowed(string detail = FailureMessages.MethodNotAllowed)
        => new("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);

    public static ErrorResult NotAcceptable(string detail = FailureMessages.NotAcceptable)
        => new("Not Acceptable", ResultStatus.NotAcceptable, detail);

    public static ErrorResult ProxyAuthenticationRequired(string detail = FailureMessages.ProxyAuthenticationRequired)
        => new("Proxy Authentication Required", ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorResult RequestTimeout(string detail = FailureMessages.RequestTimeout)
        => new("Request Timeout", ResultStatus.RequestTimeout, detail);

    public static ErrorResult Conflict(string detail)
        => new("Conflict", ResultStatus.Conflict, detail);

    public static ErrorResult Gone(string detail)
        => new("Gone", ResultStatus.Gone, detail);

    public static ErrorResult LengthRequired(string detail = FailureMessages.LengthRequired)
        => new("Length Required", ResultStatus.LengthRequired, detail);

    public static ErrorResult PreconditionFailed(string detail)
        => new("Precondition Failed", ResultStatus.PreconditionFailed, detail);

    public static ErrorResult ContentTooLarge(string detail)
        => new("Content Too Large", ResultStatus.ContentTooLarge, detail);

    public static ErrorResult UriTooLong(string detail = FailureMessages.UriTooLong)
        => new("URI Too Long", ResultStatus.UriTooLong, detail);

    public static ErrorResult UnsupportedMediaType(string detail = FailureMessages.UnsupportedMediaType)
        => new("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);

    public static ErrorResult RangeNotSatisfiable(string detail)
        => new("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorResult ExpectationFailed(string detail = FailureMessages.ExpectationFailed)
        => new("Expectation Failed", ResultStatus.ExpectationFailed, detail);

    public static ErrorResult ImATeapot(string detail = FailureMessages.ImATeapot)
        => new("I'm a Teapot", ResultStatus.ImATeapot, detail);

    public static ErrorResult MisdirectedRequest(string detail = FailureMessages.MisdirectedRequest)
        => new("Misdirected Request", ResultStatus.MisdirectedRequest, detail);

    public static ErrorResult UnprocessableContent(string detail)
        => new("Unprocessable Content", ResultStatus.UnprocessableContent, detail);

    public static ErrorResult Invalid(params string[] errors)
        => new("Validation Failed", ResultStatus.UnprocessableContent, (IReadOnlyList<string>)errors);

    public static ErrorResult Invalid(IReadOnlyList<string> errors)
        => new("Validation Failed", ResultStatus.UnprocessableContent, errors);

    public static ErrorResult Locked(string detail = FailureMessages.Locked)
        => new("Locked", ResultStatus.Locked, detail);

    public static ErrorResult FailedDependency(string detail)
        => new("Failed Dependency", ResultStatus.FailedDependency, detail);

    public static ErrorResult TooEarly(string detail = FailureMessages.TooEarly)
        => new("Too Early", ResultStatus.TooEarly, detail);

    public static ErrorResult UpgradeRequired(string detail)
        => new("Upgrade Required", ResultStatus.UpgradeRequired, detail);

    public static ErrorResult PreconditionRequired(string detail)
        => new("Precondition Required", ResultStatus.PreconditionRequired, detail);

    public static ErrorResult TooManyRequests(string detail = FailureMessages.TooManyRequests)
        => new("Too Many Requests", ResultStatus.TooManyRequests, detail);

    public static ErrorResult RequestHeaderFieldsTooLarge(string detail = FailureMessages.RequestHeaderFieldsTooLarge)
        => new("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorResult UnavailableForLegalReasons(string detail)
        => new("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorResult InternalServerError(string detail = FailureMessages.InternalServerError)
        => new("Internal Server Error", ResultStatus.InternalServerError, detail);

    public static ErrorResult NotImplemented(string detail = FailureMessages.NotImplemented)
        => new("Not Implemented", ResultStatus.NotImplemented, detail);

    public static ErrorResult BadGateway(string detail = FailureMessages.BadGateway)
        => new("Bad Gateway", ResultStatus.BadGateway, detail);

    public static ErrorResult ServiceUnavailable(string detail = FailureMessages.ServiceUnavailable)
        => new("Service Unavailable", ResultStatus.ServiceUnavailable, detail);

    public static ErrorResult GatewayTimeout(string detail = FailureMessages.GatewayTimeout)
        => new("Gateway Timeout", ResultStatus.GatewayTimeout, detail);

    public static ErrorResult HttpVersionNotSupported(string detail = FailureMessages.HttpVersionNotSupported)
        => new("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorResult VariantAlsoNegotiates(string detail = FailureMessages.VariantAlsoNegotiates)
        => new("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorResult InsufficientStorage(string detail = FailureMessages.InsufficientStorage)
        => new("Insufficient Storage", ResultStatus.InsufficientStorage, detail);

    public static ErrorResult LoopDetected(string detail = FailureMessages.LoopDetected)
        => new("Loop Detected", ResultStatus.LoopDetected, detail);

    public static ErrorResult NotExtended(string detail = FailureMessages.NotExtended)
        => new("Not Extended", ResultStatus.NotExtended, detail);

    public static ErrorResult NetworkAuthenticationRequired(string detail = FailureMessages.NetworkAuthenticationRequired)
        => new("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorDataResult<T> BadRequest<T>(string detail)
        => new("Bad Request", ResultStatus.BadRequest, detail);

    public static ErrorDataResult<T> Unauthorized<T>(string detail = FailureMessages.Unauthorized)
        => new("Unauthorized", ResultStatus.Unauthorized, detail);

    public static ErrorDataResult<T> PaymentRequired<T>(string detail)
        => new("Payment Required", ResultStatus.PaymentRequired, detail);

    public static ErrorDataResult<T> Forbidden<T>(string detail = FailureMessages.Forbidden)
        => new("Forbidden", ResultStatus.Forbidden, detail);

    public static ErrorDataResult<T> NotFound<T>(string detail)
        => new("Not Found", ResultStatus.NotFound, detail);

    public static ErrorDataResult<T> MethodNotAllowed<T>(string detail = FailureMessages.MethodNotAllowed)
        => new("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);

    public static ErrorDataResult<T> NotAcceptable<T>(string detail = FailureMessages.NotAcceptable)
        => new("Not Acceptable", ResultStatus.NotAcceptable, detail);

    public static ErrorDataResult<T> ProxyAuthenticationRequired<T>(string detail = FailureMessages.ProxyAuthenticationRequired)
        => new("Proxy Authentication Required", ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorDataResult<T> RequestTimeout<T>(string detail = FailureMessages.RequestTimeout)
        => new("Request Timeout", ResultStatus.RequestTimeout, detail);

    public static ErrorDataResult<T> Conflict<T>(string detail)
        => new("Conflict", ResultStatus.Conflict, detail);

    public static ErrorDataResult<T> Gone<T>(string detail)
        => new("Gone", ResultStatus.Gone, detail);

    public static ErrorDataResult<T> LengthRequired<T>(string detail = FailureMessages.LengthRequired)
        => new("Length Required", ResultStatus.LengthRequired, detail);

    public static ErrorDataResult<T> PreconditionFailed<T>(string detail)
        => new("Precondition Failed", ResultStatus.PreconditionFailed, detail);

    public static ErrorDataResult<T> ContentTooLarge<T>(string detail)
        => new("Content Too Large", ResultStatus.ContentTooLarge, detail);

    public static ErrorDataResult<T> UriTooLong<T>(string detail = FailureMessages.UriTooLong)
        => new("URI Too Long", ResultStatus.UriTooLong, detail);

    public static ErrorDataResult<T> UnsupportedMediaType<T>(string detail = FailureMessages.UnsupportedMediaType)
        => new("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);

    public static ErrorDataResult<T> RangeNotSatisfiable<T>(string detail)
        => new("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorDataResult<T> ExpectationFailed<T>(string detail = FailureMessages.ExpectationFailed)
        => new("Expectation Failed", ResultStatus.ExpectationFailed, detail);

    public static ErrorDataResult<T> ImATeapot<T>(string detail = FailureMessages.ImATeapot)
        => new("I'm a Teapot", ResultStatus.ImATeapot, detail);

    public static ErrorDataResult<T> MisdirectedRequest<T>(string detail = FailureMessages.MisdirectedRequest)
        => new("Misdirected Request", ResultStatus.MisdirectedRequest, detail);

    public static ErrorDataResult<T> UnprocessableContent<T>(string detail)
        => new("Unprocessable Content", ResultStatus.UnprocessableContent, detail);

    public static ErrorDataResult<T> Invalid<T>(params string[] errors)
        => new("Validation Failed", ResultStatus.UnprocessableContent, errors);

    public static ErrorDataResult<T> Invalid<T>(IReadOnlyList<string> errors)
        => new("Validation Failed", ResultStatus.UnprocessableContent, errors);

    public static ErrorDataResult<T> Locked<T>(string detail = FailureMessages.Locked)
        => new("Locked", ResultStatus.Locked, detail);

    public static ErrorDataResult<T> FailedDependency<T>(string detail)
        => new("Failed Dependency", ResultStatus.FailedDependency, detail);

    public static ErrorDataResult<T> TooEarly<T>(string detail = FailureMessages.TooEarly)
        => new("Too Early", ResultStatus.TooEarly, detail);

    public static ErrorDataResult<T> UpgradeRequired<T>(string detail)
        => new("Upgrade Required", ResultStatus.UpgradeRequired, detail);

    public static ErrorDataResult<T> PreconditionRequired<T>(string detail)
        => new("Precondition Required", ResultStatus.PreconditionRequired, detail);

    public static ErrorDataResult<T> TooManyRequests<T>(string detail = FailureMessages.TooManyRequests)
        => new("Too Many Requests", ResultStatus.TooManyRequests, detail);

    public static ErrorDataResult<T> RequestHeaderFieldsTooLarge<T>(string detail = FailureMessages.RequestHeaderFieldsTooLarge)
        => new("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorDataResult<T> UnavailableForLegalReasons<T>(string detail)
        => new("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorDataResult<T> InternalServerError<T>(string detail = FailureMessages.InternalServerError)
        => new("Internal Server Error", ResultStatus.InternalServerError, detail);

    public static ErrorDataResult<T> NotImplemented<T>(string detail = FailureMessages.NotImplemented)
        => new("Not Implemented", ResultStatus.NotImplemented, detail);

    public static ErrorDataResult<T> BadGateway<T>(string detail = FailureMessages.BadGateway)
        => new("Bad Gateway", ResultStatus.BadGateway, detail);

    public static ErrorDataResult<T> ServiceUnavailable<T>(string detail = FailureMessages.ServiceUnavailable)
        => new("Service Unavailable", ResultStatus.ServiceUnavailable, detail);

    public static ErrorDataResult<T> GatewayTimeout<T>(string detail = FailureMessages.GatewayTimeout)
        => new("Gateway Timeout", ResultStatus.GatewayTimeout, detail);

    public static ErrorDataResult<T> HttpVersionNotSupported<T>(string detail = FailureMessages.HttpVersionNotSupported)
        => new("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorDataResult<T> VariantAlsoNegotiates<T>(string detail = FailureMessages.VariantAlsoNegotiates)
        => new("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorDataResult<T> InsufficientStorage<T>(string detail = FailureMessages.InsufficientStorage)
        => new("Insufficient Storage", ResultStatus.InsufficientStorage, detail);

    public static ErrorDataResult<T> LoopDetected<T>(string detail = FailureMessages.LoopDetected)
        => new("Loop Detected", ResultStatus.LoopDetected, detail);

    public static ErrorDataResult<T> NotExtended<T>(string detail = FailureMessages.NotExtended)
        => new("Not Extended", ResultStatus.NotExtended, detail);

    public static ErrorDataResult<T> NetworkAuthenticationRequired<T>(string detail = FailureMessages.NetworkAuthenticationRequired)
        => new("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorResult Failure(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(T data, string title, string detail, ResultStatus status)
        => new(data, title, status, detail);
}
