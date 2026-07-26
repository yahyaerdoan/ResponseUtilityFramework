using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;

namespace ResultHandler;

public static partial class Results
{
    public static ErrorResult BadRequest(string detail)
    {
        return new ErrorResult("Bad Request", ResultStatus.BadRequest, detail);
    }

    public static ErrorResult Unauthorized(string detail = "Authentication is required to access this resource.")
    {
        return new ErrorResult("Unauthorized", ResultStatus.Unauthorized, detail);
    }

    public static ErrorResult PaymentRequired(string detail)
    {
        return new ErrorResult("Payment Required", ResultStatus.PaymentRequired, detail);
    }

    public static ErrorResult Forbidden(string detail = "You do not have permission to access this resource.")
    {
        return new ErrorResult("Forbidden", ResultStatus.Forbidden, detail);
    }

    public static ErrorResult NotFound(string detail)
    {
        return new ErrorResult("Not Found", ResultStatus.NotFound, detail);
    }

    public static ErrorResult MethodNotAllowed(string detail = "The HTTP method used is not allowed for this endpoint.")
    {
        return new ErrorResult("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);
    }

    public static ErrorResult NotAcceptable(string detail = "The requested media type is not supported by this server.")
    {
        return new ErrorResult("Not Acceptable", ResultStatus.NotAcceptable, detail);
    }

    public static ErrorResult RequestTimeout(string detail = "The request timed out. Please try again.")
    {
        return new ErrorResult("Request Timeout", ResultStatus.RequestTimeout, detail);
    }

    public static ErrorResult Conflict(string detail)
    {
        return new ErrorResult("Conflict", ResultStatus.Conflict, detail);
    }

    public static ErrorResult Gone(string detail)
    {
        return new ErrorResult("Gone", ResultStatus.Gone, detail);
    }

    public static ErrorResult LengthRequired(string detail = "A Content-Length header is required for this request.")
    {
        return new ErrorResult("Length Required", ResultStatus.LengthRequired, detail);
    }

    public static ErrorResult PreconditionFailed(string detail)
    {
        return new ErrorResult("Precondition Failed", ResultStatus.PreconditionFailed, detail);
    }

    public static ErrorResult ContentTooLarge(string detail)
    {
        return new ErrorResult("Content Too Large", ResultStatus.ContentTooLarge, detail);
    }

    public static ErrorResult UriTooLong(string detail = "The request URI exceeds the maximum allowed length.")
    {
        return new ErrorResult("URI Too Long", ResultStatus.UriTooLong, detail);
    }

    public static ErrorResult UnsupportedMediaType(string detail = "The submitted media type is not supported. Please use a supported type.")
    {
        return new ErrorResult("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);
    }

    public static ErrorResult RangeNotSatisfiable(string detail)
    {
        return new ErrorResult("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);
    }

    public static ErrorResult ExpectationFailed(string detail = "The expectation given in the Expect header could not be met.")
    {
        return new ErrorResult("Expectation Failed", ResultStatus.ExpectationFailed, detail);
    }

    public static ErrorResult ImATeapot(string detail = "I'm a teapot.")
    {
        return new ErrorResult("I'm a Teapot", ResultStatus.ImATeapot, detail);
    }

    public static ErrorResult MisdirectedRequest(string detail = "The request was directed to a server unable to produce a response.")
    {
        return new ErrorResult("Misdirected Request", ResultStatus.MisdirectedRequest, detail);
    }

    public static ErrorResult UnprocessableEntity(string detail)
    {
        return new ErrorResult("Unprocessable Entity", ResultStatus.Invalid, detail);
    }

    public static ErrorResult Invalid(params string[] errors)
    {
        return new ErrorResult("Validation Failed", ResultStatus.Invalid, (IReadOnlyList<string>)errors);
    }

    public static ErrorResult Invalid(IReadOnlyList<string> errors)
    {
        return new ErrorResult("Validation Failed", ResultStatus.Invalid, errors);
    }

    public static ErrorResult Locked(string detail = "The resource is currently locked and cannot be modified.")
    {
        return new ErrorResult("Locked", ResultStatus.Locked, detail);
    }

    public static ErrorResult FailedDependency(string detail)
    {
        return new ErrorResult("Failed Dependency", ResultStatus.FailedDependency, detail);
    }

    public static ErrorResult TooEarly(string detail = "The request was rejected because it may be replayed.")
    {
        return new ErrorResult("Too Early", ResultStatus.TooEarly, detail);
    }

    public static ErrorResult UpgradeRequired(string detail)
    {
        return new ErrorResult("Upgrade Required", ResultStatus.UpgradeRequired, detail);
    }

    public static ErrorResult PreconditionRequired(string detail)
    {
        return new ErrorResult("Precondition Required", ResultStatus.PreconditionRequired, detail);
    }

    public static ErrorResult TooManyRequests(string detail = "Too many requests. Please slow down and try again later.")
    {
        return new ErrorResult("Too Many Requests", ResultStatus.TooManyRequests, detail);
    }

    public static ErrorResult RequestHeaderFieldsTooLarge(string detail = "One or more request header fields exceed the maximum allowed size.")
    {
        return new ErrorResult("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);
    }

    public static ErrorResult UnavailableForLegalReasons(string detail)
    {
        return new ErrorResult("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);
    }

    public static ErrorResult InternalServerError(string detail = "An unexpected error occurred. Please try again later.")
    {
        return new ErrorResult("Internal Server Error", ResultStatus.Error, detail);
    }

    public static ErrorResult NotImplemented(string detail = "This feature is not yet implemented.")
    {
        return new ErrorResult("Not Implemented", ResultStatus.NotImplemented, detail);
    }

    public static ErrorResult BadGateway(string detail = "An upstream server returned an invalid response.")
    {
        return new ErrorResult("Bad Gateway", ResultStatus.BadGateway, detail);
    }

    public static ErrorResult ServiceUnavailable(string detail = "The service is temporarily unavailable. Please try again later.")
    {
        return new ErrorResult("Service Unavailable", ResultStatus.Unavailable, detail);
    }

    public static ErrorResult GatewayTimeout(string detail = "An upstream server did not respond in time.")
    {
        return new ErrorResult("Gateway Timeout", ResultStatus.GatewayTimeout, detail);
    }

    public static ErrorResult HttpVersionNotSupported(string detail = "The HTTP version used in the request is not supported.")
    {
        return new ErrorResult("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);
    }

    public static ErrorResult VariantAlsoNegotiates(string detail = "The server has an internal configuration error.")
    {
        return new ErrorResult("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);
    }

    public static ErrorResult InsufficientStorage(string detail = "Insufficient storage to complete the request.")
    {
        return new ErrorResult("Insufficient Storage", ResultStatus.InsufficientStorage, detail);
    }

    public static ErrorResult LoopDetected(string detail = "The server detected an infinite loop while processing the request.")
    {
        return new ErrorResult("Loop Detected", ResultStatus.LoopDetected, detail);
    }

    public static ErrorResult NotExtended(string detail = "Further extensions to the request are required.")
    {
        return new ErrorResult("Not Extended", ResultStatus.NotExtended, detail);
    }

    public static ErrorResult NetworkAuthenticationRequired(string detail = "Network authentication is required to access this resource.")
    {
        return new ErrorResult("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);
    }

    public static ErrorDataResult<T> BadRequest<T>(string detail)
    {
        return new ErrorDataResult<T>("Bad Request", ResultStatus.BadRequest, detail);
    }

    public static ErrorDataResult<T> Unauthorized<T>(string detail = "Authentication is required to access this resource.")
    {
        return new ErrorDataResult<T>("Unauthorized", ResultStatus.Unauthorized, detail);
    }

    public static ErrorDataResult<T> PaymentRequired<T>(string detail)
    {
        return new ErrorDataResult<T>("Payment Required", ResultStatus.PaymentRequired, detail);
    }

    public static ErrorDataResult<T> Forbidden<T>(string detail = "You do not have permission to access this resource.")
    {
        return new ErrorDataResult<T>("Forbidden", ResultStatus.Forbidden, detail);
    }

    public static ErrorDataResult<T> NotFound<T>(string detail)
    {
        return new ErrorDataResult<T>("Not Found", ResultStatus.NotFound, detail);
    }

    public static ErrorDataResult<T> MethodNotAllowed<T>(string detail = "The HTTP method used is not allowed for this endpoint.")
    {
        return new ErrorDataResult<T>("Method Not Allowed", ResultStatus.MethodNotAllowed, detail);
    }

    public static ErrorDataResult<T> NotAcceptable<T>(string detail = "The requested media type is not supported by this server.")
    {
        return new ErrorDataResult<T>("Not Acceptable", ResultStatus.NotAcceptable, detail);
    }

    public static ErrorDataResult<T> RequestTimeout<T>(string detail = "The request timed out. Please try again.")
    {
        return new ErrorDataResult<T>("Request Timeout", ResultStatus.RequestTimeout, detail);
    }

    public static ErrorDataResult<T> Conflict<T>(string detail)
    {
        return new ErrorDataResult<T>("Conflict", ResultStatus.Conflict, detail);
    }

    public static ErrorDataResult<T> Gone<T>(string detail)
    {
        return new ErrorDataResult<T>("Gone", ResultStatus.Gone, detail);
    }

    public static ErrorDataResult<T> LengthRequired<T>(string detail = "A Content-Length header is required for this request.")
    {
        return new ErrorDataResult<T>("Length Required", ResultStatus.LengthRequired, detail);
    }

    public static ErrorDataResult<T> PreconditionFailed<T>(string detail)
    {
        return new ErrorDataResult<T>("Precondition Failed", ResultStatus.PreconditionFailed, detail);
    }

    public static ErrorDataResult<T> ContentTooLarge<T>(string detail)
    {
        return new ErrorDataResult<T>("Content Too Large", ResultStatus.ContentTooLarge, detail);
    }

    public static ErrorDataResult<T> UriTooLong<T>(string detail = "The request URI exceeds the maximum allowed length.")
    {
        return new ErrorDataResult<T>("URI Too Long", ResultStatus.UriTooLong, detail);
    }

    public static ErrorDataResult<T> UnsupportedMediaType<T>(string detail = "The submitted media type is not supported. Please use a supported type.")
    {
        return new ErrorDataResult<T>("Unsupported Media Type", ResultStatus.UnsupportedMediaType, detail);
    }

    public static ErrorDataResult<T> RangeNotSatisfiable<T>(string detail)
    {
        return new ErrorDataResult<T>("Range Not Satisfiable", ResultStatus.RangeNotSatisfiable, detail);
    }

    public static ErrorDataResult<T> ExpectationFailed<T>(string detail = "The expectation given in the Expect header could not be met.")
    {
        return new ErrorDataResult<T>("Expectation Failed", ResultStatus.ExpectationFailed, detail);
    }

    public static ErrorDataResult<T> ImATeapot<T>(string detail = "I'm a teapot.")
    {
        return new ErrorDataResult<T>("I'm a Teapot", ResultStatus.ImATeapot, detail);
    }

    public static ErrorDataResult<T> MisdirectedRequest<T>(string detail = "The request was directed to a server unable to produce a response.")
    {
        return new ErrorDataResult<T>("Misdirected Request", ResultStatus.MisdirectedRequest, detail);
    }

    public static ErrorDataResult<T> UnprocessableEntity<T>(string detail)
    {
        return new ErrorDataResult<T>("Unprocessable Entity", ResultStatus.Invalid, detail);
    }

    public static ErrorDataResult<T> Invalid<T>(params string[] errors)
    {
        return new ErrorDataResult<T>("Validation Failed", ResultStatus.Invalid, (IReadOnlyList<string>)errors);
    }

    public static ErrorDataResult<T> Locked<T>(string detail = "The resource is currently locked and cannot be modified.")
    {
        return new ErrorDataResult<T>("Locked", ResultStatus.Locked, detail);
    }

    public static ErrorDataResult<T> FailedDependency<T>(string detail)
    {
        return new ErrorDataResult<T>("Failed Dependency", ResultStatus.FailedDependency, detail);
    }

    public static ErrorDataResult<T> TooEarly<T>(string detail = "The request was rejected because it may be replayed.")
    {
        return new ErrorDataResult<T>("Too Early", ResultStatus.TooEarly, detail);
    }

    public static ErrorDataResult<T> UpgradeRequired<T>(string detail)
    {
        return new ErrorDataResult<T>("Upgrade Required", ResultStatus.UpgradeRequired, detail);
    }

    public static ErrorDataResult<T> PreconditionRequired<T>(string detail)
    {
        return new ErrorDataResult<T>("Precondition Required", ResultStatus.PreconditionRequired, detail);
    }

    public static ErrorDataResult<T> TooManyRequests<T>(string detail = "Too many requests. Please slow down and try again later.")
    {
        return new ErrorDataResult<T>("Too Many Requests", ResultStatus.TooManyRequests, detail);
    }

    public static ErrorDataResult<T> RequestHeaderFieldsTooLarge<T>(string detail = "One or more request header fields exceed the maximum allowed size.")
    {
        return new ErrorDataResult<T>("Request Header Fields Too Large", ResultStatus.RequestHeaderFieldsTooLarge, detail);
    }

    public static ErrorDataResult<T> UnavailableForLegalReasons<T>(string detail)
    {
        return new ErrorDataResult<T>("Unavailable For Legal Reasons", ResultStatus.UnavailableForLegalReasons, detail);
    }

    public static ErrorDataResult<T> InternalServerError<T>(string detail = "An unexpected error occurred. Please try again later.")
    {
        return new ErrorDataResult<T>("Internal Server Error", ResultStatus.Error, detail);
    }

    public static ErrorDataResult<T> NotImplemented<T>(string detail = "This feature is not yet implemented.")
    {
        return new ErrorDataResult<T>("Not Implemented", ResultStatus.NotImplemented, detail);
    }

    public static ErrorDataResult<T> BadGateway<T>(string detail = "An upstream server returned an invalid response.")
    {
        return new ErrorDataResult<T>("Bad Gateway", ResultStatus.BadGateway, detail);
    }

    public static ErrorDataResult<T> ServiceUnavailable<T>(string detail = "The service is temporarily unavailable. Please try again later.")
    {
        return new ErrorDataResult<T>("Service Unavailable", ResultStatus.Unavailable, detail);
    }

    public static ErrorDataResult<T> GatewayTimeout<T>(string detail = "An upstream server did not respond in time.")
    {
        return new ErrorDataResult<T>("Gateway Timeout", ResultStatus.GatewayTimeout, detail);
    }

    public static ErrorDataResult<T> HttpVersionNotSupported<T>(string detail = "The HTTP version used in the request is not supported.")
    {
        return new ErrorDataResult<T>("HTTP Version Not Supported", ResultStatus.HttpVersionNotSupported, detail);
    }

    public static ErrorDataResult<T> VariantAlsoNegotiates<T>(string detail = "The server has an internal configuration error.")
    {
        return new ErrorDataResult<T>("Variant Also Negotiates", ResultStatus.VariantAlsoNegotiates, detail);
    }

    public static ErrorDataResult<T> InsufficientStorage<T>(string detail = "Insufficient storage to complete the request.")
    {
        return new ErrorDataResult<T>("Insufficient Storage", ResultStatus.InsufficientStorage, detail);
    }

    public static ErrorDataResult<T> LoopDetected<T>(string detail = "The server detected an infinite loop while processing the request.")
    {
        return new ErrorDataResult<T>("Loop Detected", ResultStatus.LoopDetected, detail);
    }

    public static ErrorDataResult<T> NotExtended<T>(string detail = "Further extensions to the request are required.")
    {
        return new ErrorDataResult<T>("Not Extended", ResultStatus.NotExtended, detail);
    }

    public static ErrorDataResult<T> NetworkAuthenticationRequired<T>(string detail = "Network authentication is required to access this resource.")
    {
        return new ErrorDataResult<T>("Network Authentication Required", ResultStatus.NetworkAuthenticationRequired, detail);
    }

    public static ErrorResult Failure(string title, string detail, ResultStatus status)
    {
        return new ErrorResult(title, status, detail);
    }

    public static ErrorDataResult<T> Failure<T>(string title, string detail, ResultStatus status)
    {
        return new ErrorDataResult<T>(title, status, detail);
    }

    public static ErrorDataResult<T> Failure<T>(T data, string title, string detail, ResultStatus status)
    {
        return new ErrorDataResult<T>(data, title, status, detail);
    }
}
