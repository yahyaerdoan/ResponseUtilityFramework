using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;

namespace ResultHandler.Facade;

public static partial class Results
{
    public static ErrorResult BadRequest(string detail)
        => new("Bad Request", ResultStatus.BadRequest, detail);

    public static ErrorResult Unauthorized(string detail = "Authentication is required to access this resource.")
        => new("Unauthorized", ResultStatus.Unauthorized, detail);

    public static ErrorResult PaymentRequired(string detail)
        => new("Payment Required", ResultStatus.PaymentRequired, detail);

    public static ErrorResult Forbidden(string detail = "You do not have permission to access this resource.")
        => new("Forbidden", ResultStatus.Forbidden, detail);

    public static ErrorResult NotFound(string detail)
        => new("Not Found", ResultStatus.NotFound, detail);

    public static ErrorResult MethodNotAllowed(string detail = "The HTTP method used is not allowed for this endpoint.")
        => new("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);

    public static ErrorResult NotAcceptable(string detail = "The requested media type is not supported by this server.")
        => new("Not Acceptable", ResultStatus.NotAcceptable, detail);

    public static ErrorResult ProxyAuthenticationRequired(string detail = "Proxy authentication is required to access this resource.")
        => new("Proxy Authentication Required", ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorResult RequestTimeout(string detail = "The request timed out. Please try again.")
        => new("Request Timeout", ResultStatus.RequestTimeout, detail);

    public static ErrorResult Conflict(string detail)
        => new("Conflict", ResultStatus.Conflict, detail);

    public static ErrorResult Gone(string detail)
        => new("Gone", ResultStatus.Gone, detail);

    public static ErrorResult LengthRequired(string detail = "A Content-Length header is required for this request.")
        => new("Length Required", ResultStatus.LengthRequired, detail);

    public static ErrorResult PreconditionFailed(string detail)
        => new("Precondition Failed", ResultStatus.PreconditionFailed, detail);

    public static ErrorResult ContentTooLarge(string detail)
        => new("Content Too Large", ResultStatus.ContentTooLarge, detail);

    public static ErrorResult UriTooLong(string detail = "The request URI exceeds the maximum allowed length.")
        => new("URI Too Long", ResultStatus.UriTooLong, detail);

    public static ErrorResult UnsupportedMediaType(string detail = "The submitted media type is not supported. Please use a supported type.")
        => new("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);

    public static ErrorResult RangeNotSatisfiable(string detail)
        => new("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorResult ExpectationFailed(string detail = "The expectation given in the Expect header could not be met.")
        => new("Expectation Failed", ResultStatus.ExpectationFailed, detail);

    public static ErrorResult ImATeapot(string detail = "I'm a teapot.")
        => new("I'm a Teapot", ResultStatus.ImATeapot, detail);

    public static ErrorResult MisdirectedRequest(string detail = "The request was directed to a server unable to produce a response.")
        => new("Misdirected Request", ResultStatus.MisdirectedRequest, detail);

    public static ErrorResult UnprocessableEntity(string detail)
        => new("Unprocessable Entity", ResultStatus.Invalid, detail);

    public static ErrorResult Invalid(params string[] errors)
        => new("Validation Failed", ResultStatus.Invalid, (IReadOnlyList<string>)errors);

    public static ErrorResult Invalid(IReadOnlyList<string> errors)
        => new("Validation Failed", ResultStatus.Invalid, errors);

    public static ErrorResult Locked(string detail = "The resource is currently locked and cannot be modified.")
        => new("Locked", ResultStatus.Locked, detail);

    public static ErrorResult FailedDependency(string detail)
        => new("Failed Dependency", ResultStatus.FailedDependency, detail);

    public static ErrorResult TooEarly(string detail = "The request was rejected because it may be replayed.")
        => new("Too Early", ResultStatus.TooEarly, detail);

    public static ErrorResult UpgradeRequired(string detail)
        => new("Upgrade Required", ResultStatus.UpgradeRequired, detail);

    public static ErrorResult PreconditionRequired(string detail)
        => new("Precondition Required", ResultStatus.PreconditionRequired, detail);

    public static ErrorResult TooManyRequests(string detail = "Too many requests. Please slow down and try again later.")
        => new("Too Many Requests", ResultStatus.TooManyRequests, detail);

    public static ErrorResult RequestHeaderFieldsTooLarge(string detail = "One or more request header fields exceed the maximum allowed size.")
        => new("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorResult UnavailableForLegalReasons(string detail)
        => new("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorResult InternalServerError(string detail = "An unexpected error occurred. Please try again later.")
        => new("Internal Server Error", ResultStatus.Error, detail);

    public static ErrorResult NotImplemented(string detail = "This feature is not yet implemented.")
        => new("Not Implemented", ResultStatus.NotImplemented, detail);

    public static ErrorResult BadGateway(string detail = "An upstream server returned an invalid response.")
        => new("Bad Gateway", ResultStatus.BadGateway, detail);

    public static ErrorResult ServiceUnavailable(string detail = "The service is temporarily unavailable. Please try again later.")
        => new("Service Unavailable", ResultStatus.Unavailable, detail);

    public static ErrorResult GatewayTimeout(string detail = "An upstream server did not respond in time.")
        => new("Gateway Timeout", ResultStatus.GatewayTimeout, detail);

    public static ErrorResult HttpVersionNotSupported(string detail = "The HTTP version used in the request is not supported.")
        => new("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorResult VariantAlsoNegotiates(string detail = "The server has an internal configuration error.")
        => new("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorResult InsufficientStorage(string detail = "Insufficient storage to complete the request.")
        => new("Insufficient Storage", ResultStatus.InsufficientStorage, detail);

    public static ErrorResult LoopDetected(string detail = "The server detected an infinite loop while processing the request.")
        => new("Loop Detected", ResultStatus.LoopDetected, detail);

    public static ErrorResult NotExtended(string detail = "Further extensions to the request are required.")
        => new("Not Extended", ResultStatus.NotExtended, detail);

    public static ErrorResult NetworkAuthenticationRequired(string detail = "Network authentication is required to access this resource.")
        => new("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorDataResult<T> BadRequest<T>(string detail)
        => new("Bad Request", ResultStatus.BadRequest, detail);

    public static ErrorDataResult<T> Unauthorized<T>(string detail = "Authentication is required to access this resource.")
        => new("Unauthorized", ResultStatus.Unauthorized, detail);

    public static ErrorDataResult<T> PaymentRequired<T>(string detail)
        => new("Payment Required", ResultStatus.PaymentRequired, detail);

    public static ErrorDataResult<T> Forbidden<T>(string detail = "You do not have permission to access this resource.")
        => new("Forbidden", ResultStatus.Forbidden, detail);

    public static ErrorDataResult<T> NotFound<T>(string detail)
        => new("Not Found", ResultStatus.NotFound, detail);

    public static ErrorDataResult<T> MethodNotAllowed<T>(string detail = "The HTTP method used is not allowed for this endpoint.")
        => new("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);

    public static ErrorDataResult<T> NotAcceptable<T>(string detail = "The requested media type is not supported by this server.")
        => new("Not Acceptable", ResultStatus.NotAcceptable, detail);

    public static ErrorDataResult<T> ProxyAuthenticationRequired<T>(string detail = "Proxy authentication is required to access this resource.")
        => new("Proxy Authentication Required", ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorDataResult<T> RequestTimeout<T>(string detail = "The request timed out. Please try again.")
        => new("Request Timeout", ResultStatus.RequestTimeout, detail);

    public static ErrorDataResult<T> Conflict<T>(string detail)
        => new("Conflict", ResultStatus.Conflict, detail);

    public static ErrorDataResult<T> Gone<T>(string detail)
        => new("Gone", ResultStatus.Gone, detail);

    public static ErrorDataResult<T> LengthRequired<T>(string detail = "A Content-Length header is required for this request.")
        => new("Length Required", ResultStatus.LengthRequired, detail);

    public static ErrorDataResult<T> PreconditionFailed<T>(string detail)
        => new("Precondition Failed", ResultStatus.PreconditionFailed, detail);

    public static ErrorDataResult<T> ContentTooLarge<T>(string detail)
        => new("Content Too Large", ResultStatus.ContentTooLarge, detail);

    public static ErrorDataResult<T> UriTooLong<T>(string detail = "The request URI exceeds the maximum allowed length.")
        => new("URI Too Long", ResultStatus.UriTooLong, detail);

    public static ErrorDataResult<T> UnsupportedMediaType<T>(string detail = "The submitted media type is not supported. Please use a supported type.")
        => new("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);

    public static ErrorDataResult<T> RangeNotSatisfiable<T>(string detail)
        => new("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorDataResult<T> ExpectationFailed<T>(string detail = "The expectation given in the Expect header could not be met.")
        => new("Expectation Failed", ResultStatus.ExpectationFailed, detail);

    public static ErrorDataResult<T> ImATeapot<T>(string detail = "I'm a teapot.")
        => new("I'm a Teapot", ResultStatus.ImATeapot, detail);

    public static ErrorDataResult<T> MisdirectedRequest<T>(string detail = "The request was directed to a server unable to produce a response.")
        => new("Misdirected Request", ResultStatus.MisdirectedRequest, detail);

    public static ErrorDataResult<T> UnprocessableEntity<T>(string detail)
        => new("Unprocessable Entity", ResultStatus.Invalid, detail);

    public static ErrorDataResult<T> Invalid<T>(params string[] errors)
        => new("Validation Failed", ResultStatus.Invalid, errors);

    public static ErrorDataResult<T> Invalid<T>(IReadOnlyList<string> errors)
        => new("Validation Failed", ResultStatus.Invalid, errors);

    public static ErrorDataResult<T> Locked<T>(string detail = "The resource is currently locked and cannot be modified.")
        => new("Locked", ResultStatus.Locked, detail);

    public static ErrorDataResult<T> FailedDependency<T>(string detail)
        => new("Failed Dependency", ResultStatus.FailedDependency, detail);

    public static ErrorDataResult<T> TooEarly<T>(string detail = "The request was rejected because it may be replayed.")
        => new("Too Early", ResultStatus.TooEarly, detail);

    public static ErrorDataResult<T> UpgradeRequired<T>(string detail)
        => new("Upgrade Required", ResultStatus.UpgradeRequired, detail);

    public static ErrorDataResult<T> PreconditionRequired<T>(string detail)
        => new("Precondition Required", ResultStatus.PreconditionRequired, detail);

    public static ErrorDataResult<T> TooManyRequests<T>(string detail = "Too many requests. Please slow down and try again later.")
        => new("Too Many Requests", ResultStatus.TooManyRequests, detail);

    public static ErrorDataResult<T> RequestHeaderFieldsTooLarge<T>(string detail = "One or more request header fields exceed the maximum allowed size.")
        => new("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorDataResult<T> UnavailableForLegalReasons<T>(string detail)
        => new("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorDataResult<T> InternalServerError<T>(string detail = "An unexpected error occurred. Please try again later.")
        => new("Internal Server Error", ResultStatus.Error, detail);

    public static ErrorDataResult<T> NotImplemented<T>(string detail = "This feature is not yet implemented.")
        => new("Not Implemented", ResultStatus.NotImplemented, detail);

    public static ErrorDataResult<T> BadGateway<T>(string detail = "An upstream server returned an invalid response.")
        => new("Bad Gateway", ResultStatus.BadGateway, detail);

    public static ErrorDataResult<T> ServiceUnavailable<T>(string detail = "The service is temporarily unavailable. Please try again later.")
        => new("Service Unavailable", ResultStatus.Unavailable, detail);

    public static ErrorDataResult<T> GatewayTimeout<T>(string detail = "An upstream server did not respond in time.")
        => new("Gateway Timeout", ResultStatus.GatewayTimeout, detail);

    public static ErrorDataResult<T> HttpVersionNotSupported<T>(string detail = "The HTTP version used in the request is not supported.")
        => new("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorDataResult<T> VariantAlsoNegotiates<T>(string detail = "The server has an internal configuration error.")
        => new("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorDataResult<T> InsufficientStorage<T>(string detail = "Insufficient storage to complete the request.")
        => new("Insufficient Storage", ResultStatus.InsufficientStorage, detail);

    public static ErrorDataResult<T> LoopDetected<T>(string detail = "The server detected an infinite loop while processing the request.")
        => new("Loop Detected", ResultStatus.LoopDetected, detail);

    public static ErrorDataResult<T> NotExtended<T>(string detail = "Further extensions to the request are required.")
        => new("Not Extended", ResultStatus.NotExtended, detail);

    public static ErrorDataResult<T> NetworkAuthenticationRequired<T>(string detail = "Network authentication is required to access this resource.")
        => new("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorResult Failure(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(T data, string title, string detail, ResultStatus status)
        => new(data, title, status, detail);
}
