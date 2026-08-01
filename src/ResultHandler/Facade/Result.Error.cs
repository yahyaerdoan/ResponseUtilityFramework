using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;

namespace ResultHandler.Facade;

public static partial class Result
{
    public static ErrorResult BadRequest(string detail)
        => new(ResultTitles.BadRequest, ResultStatus.BadRequest, detail);

    public static ErrorDataResult<T> BadRequest<T>(string detail)
        => new(ResultTitles.BadRequest, ResultStatus.BadRequest, detail);

    public static ErrorResult Unauthorized(string detail = FailureMessages.Unauthorized)
        => new(ResultTitles.Unauthorized, ResultStatus.Unauthorized, detail);

    public static ErrorDataResult<T> Unauthorized<T>(string detail = FailureMessages.Unauthorized)
        => new(ResultTitles.Unauthorized, ResultStatus.Unauthorized, detail);

    public static ErrorResult PaymentRequired(string detail)
        => new(ResultTitles.PaymentRequired, ResultStatus.PaymentRequired, detail);

    public static ErrorDataResult<T> PaymentRequired<T>(string detail)
        => new(ResultTitles.PaymentRequired, ResultStatus.PaymentRequired, detail);

    public static ErrorResult Forbidden(string detail = FailureMessages.Forbidden)
        => new(ResultTitles.Forbidden, ResultStatus.Forbidden, detail);

    public static ErrorDataResult<T> Forbidden<T>(string detail = FailureMessages.Forbidden)
        => new(ResultTitles.Forbidden, ResultStatus.Forbidden, detail);

    public static ErrorResult NotFound(string detail)
        => new(ResultTitles.NotFound, ResultStatus.NotFound, detail);

    public static ErrorDataResult<T> NotFound<T>(string detail)
        => new(ResultTitles.NotFound, ResultStatus.NotFound, detail);

    public static ErrorResult MethodNotAllowed(string detail = FailureMessages.MethodNotAllowed)
        => new(ResultTitles.MethodNotAllowed, ResultStatus.MethodNotAllowed, detail);

    public static ErrorDataResult<T> MethodNotAllowed<T>(string detail = FailureMessages.MethodNotAllowed)
        => new(ResultTitles.MethodNotAllowed, ResultStatus.MethodNotAllowed, detail);

    public static ErrorResult NotAcceptable(string detail = FailureMessages.NotAcceptable)
        => new(ResultTitles.NotAcceptable, ResultStatus.NotAcceptable, detail);

    public static ErrorDataResult<T> NotAcceptable<T>(string detail = FailureMessages.NotAcceptable)
        => new(ResultTitles.NotAcceptable, ResultStatus.NotAcceptable, detail);

    public static ErrorResult ProxyAuthenticationRequired(string detail = FailureMessages.ProxyAuthenticationRequired)
        => new(ResultTitles.ProxyAuthenticationRequired, ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorDataResult<T> ProxyAuthenticationRequired<T>(string detail = FailureMessages.ProxyAuthenticationRequired)
        => new(ResultTitles.ProxyAuthenticationRequired, ResultStatus.ProxyAuthenticationRequired, detail);

    public static ErrorResult RequestTimeout(string detail = FailureMessages.RequestTimeout)
        => new(ResultTitles.RequestTimeout, ResultStatus.RequestTimeout, detail);

    public static ErrorDataResult<T> RequestTimeout<T>(string detail = FailureMessages.RequestTimeout)
        => new(ResultTitles.RequestTimeout, ResultStatus.RequestTimeout, detail);

    public static ErrorResult Conflict(string detail)
        => new(ResultTitles.Conflict, ResultStatus.Conflict, detail);

    public static ErrorDataResult<T> Conflict<T>(string detail)
        => new(ResultTitles.Conflict, ResultStatus.Conflict, detail);

    public static ErrorResult Gone(string detail)
        => new(ResultTitles.Gone, ResultStatus.Gone, detail);

    public static ErrorDataResult<T> Gone<T>(string detail)
        => new(ResultTitles.Gone, ResultStatus.Gone, detail);

    public static ErrorResult LengthRequired(string detail = FailureMessages.LengthRequired)
        => new(ResultTitles.LengthRequired, ResultStatus.LengthRequired, detail);

    public static ErrorDataResult<T> LengthRequired<T>(string detail = FailureMessages.LengthRequired)
        => new(ResultTitles.LengthRequired, ResultStatus.LengthRequired, detail);

    public static ErrorResult PreconditionFailed(string detail)
        => new(ResultTitles.PreconditionFailed, ResultStatus.PreconditionFailed, detail);

    public static ErrorDataResult<T> PreconditionFailed<T>(string detail)
        => new(ResultTitles.PreconditionFailed, ResultStatus.PreconditionFailed, detail);

    public static ErrorResult ContentTooLarge(string detail)
        => new(ResultTitles.ContentTooLarge, ResultStatus.ContentTooLarge, detail);

    public static ErrorDataResult<T> ContentTooLarge<T>(string detail)
        => new(ResultTitles.ContentTooLarge, ResultStatus.ContentTooLarge, detail);

    public static ErrorResult UriTooLong(string detail = FailureMessages.UriTooLong)
        => new(ResultTitles.UriTooLong, ResultStatus.UriTooLong, detail);

    public static ErrorDataResult<T> UriTooLong<T>(string detail = FailureMessages.UriTooLong)
        => new(ResultTitles.UriTooLong, ResultStatus.UriTooLong, detail);

    public static ErrorResult UnsupportedMediaType(string detail = FailureMessages.UnsupportedMediaType)
        => new(ResultTitles.UnsupportedMediaType, ResultStatus.UnsupportedMediaType, detail);

    public static ErrorDataResult<T> UnsupportedMediaType<T>(string detail = FailureMessages.UnsupportedMediaType)
        => new(ResultTitles.UnsupportedMediaType, ResultStatus.UnsupportedMediaType, detail);

    public static ErrorResult RangeNotSatisfiable(string detail)
        => new(ResultTitles.RangeNotSatisfiable, ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorDataResult<T> RangeNotSatisfiable<T>(string detail)
        => new(ResultTitles.RangeNotSatisfiable, ResultStatus.RangeNotSatisfiable, detail);

    public static ErrorResult ExpectationFailed(string detail = FailureMessages.ExpectationFailed)
        => new(ResultTitles.ExpectationFailed, ResultStatus.ExpectationFailed, detail);

    public static ErrorDataResult<T> ExpectationFailed<T>(string detail = FailureMessages.ExpectationFailed)
        => new(ResultTitles.ExpectationFailed, ResultStatus.ExpectationFailed, detail);

    public static ErrorResult ImATeapot(string detail = FailureMessages.ImATeapot)
        => new(ResultTitles.ImATeapot, ResultStatus.ImATeapot, detail);

    public static ErrorDataResult<T> ImATeapot<T>(string detail = FailureMessages.ImATeapot)
        => new(ResultTitles.ImATeapot, ResultStatus.ImATeapot, detail);

    public static ErrorResult MisdirectedRequest(string detail = FailureMessages.MisdirectedRequest)
        => new(ResultTitles.MisdirectedRequest, ResultStatus.MisdirectedRequest, detail);

    public static ErrorDataResult<T> MisdirectedRequest<T>(string detail = FailureMessages.MisdirectedRequest)
        => new(ResultTitles.MisdirectedRequest, ResultStatus.MisdirectedRequest, detail);

    public static ErrorResult UnprocessableContent(string detail)
        => new(ResultTitles.UnprocessableContent, ResultStatus.UnprocessableContent, detail);

    public static ErrorDataResult<T> UnprocessableContent<T>(string detail)
        => new(ResultTitles.UnprocessableContent, ResultStatus.UnprocessableContent, detail);

    public static ErrorResult Invalid(params string[] errors)
        => new(ResultTitles.ValidationFailed, ResultStatus.UnprocessableContent, (IReadOnlyList<string>)errors);

    public static ErrorResult Invalid(IReadOnlyList<string> errors)
        => new(ResultTitles.ValidationFailed, ResultStatus.UnprocessableContent, errors);

    public static ErrorDataResult<T> Invalid<T>(params string[] errors)
        => new(ResultTitles.ValidationFailed, ResultStatus.UnprocessableContent, errors);

    public static ErrorDataResult<T> Invalid<T>(IReadOnlyList<string> errors)
        => new(ResultTitles.ValidationFailed, ResultStatus.UnprocessableContent, errors);

    public static ErrorResult Locked(string detail = FailureMessages.Locked)
        => new(ResultTitles.Locked, ResultStatus.Locked, detail);

    public static ErrorDataResult<T> Locked<T>(string detail = FailureMessages.Locked)
        => new(ResultTitles.Locked, ResultStatus.Locked, detail);

    public static ErrorResult FailedDependency(string detail)
        => new(ResultTitles.FailedDependency, ResultStatus.FailedDependency, detail);

    public static ErrorDataResult<T> FailedDependency<T>(string detail)
        => new(ResultTitles.FailedDependency, ResultStatus.FailedDependency, detail);

    public static ErrorResult TooEarly(string detail = FailureMessages.TooEarly)
        => new(ResultTitles.TooEarly, ResultStatus.TooEarly, detail);

    public static ErrorDataResult<T> TooEarly<T>(string detail = FailureMessages.TooEarly)
        => new(ResultTitles.TooEarly, ResultStatus.TooEarly, detail);

    public static ErrorResult UpgradeRequired(string detail)
        => new(ResultTitles.UpgradeRequired, ResultStatus.UpgradeRequired, detail);

    public static ErrorDataResult<T> UpgradeRequired<T>(string detail)
        => new(ResultTitles.UpgradeRequired, ResultStatus.UpgradeRequired, detail);

    public static ErrorResult PreconditionRequired(string detail)
        => new(ResultTitles.PreconditionRequired, ResultStatus.PreconditionRequired, detail);

    public static ErrorDataResult<T> PreconditionRequired<T>(string detail)
        => new(ResultTitles.PreconditionRequired, ResultStatus.PreconditionRequired, detail);

    public static ErrorResult TooManyRequests(string detail = FailureMessages.TooManyRequests)
        => new(ResultTitles.TooManyRequests, ResultStatus.TooManyRequests, detail);

    public static ErrorDataResult<T> TooManyRequests<T>(string detail = FailureMessages.TooManyRequests)
        => new(ResultTitles.TooManyRequests, ResultStatus.TooManyRequests, detail);

    public static ErrorResult RequestHeaderFieldsTooLarge(string detail = FailureMessages.RequestHeaderFieldsTooLarge)
        => new(ResultTitles.RequestHeaderFieldsTooLarge, ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorDataResult<T> RequestHeaderFieldsTooLarge<T>(string detail = FailureMessages.RequestHeaderFieldsTooLarge)
        => new(ResultTitles.RequestHeaderFieldsTooLarge, ResultStatus.RequestHeaderFieldsTooLarge, detail);

    public static ErrorResult UnavailableForLegalReasons(string detail)
        => new(ResultTitles.UnavailableForLegalReasons, ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorDataResult<T> UnavailableForLegalReasons<T>(string detail)
        => new(ResultTitles.UnavailableForLegalReasons, ResultStatus.UnavailableForLegalReasons, detail);

    public static ErrorResult InternalServerError(string detail = FailureMessages.InternalServerError)
        => new(ResultTitles.InternalServerError, ResultStatus.InternalServerError, detail);

    public static ErrorDataResult<T> InternalServerError<T>(string detail = FailureMessages.InternalServerError)
        => new(ResultTitles.InternalServerError, ResultStatus.InternalServerError, detail);

    public static ErrorResult NotImplemented(string detail = FailureMessages.NotImplemented)
        => new(ResultTitles.NotImplemented, ResultStatus.NotImplemented, detail);

    public static ErrorDataResult<T> NotImplemented<T>(string detail = FailureMessages.NotImplemented)
        => new(ResultTitles.NotImplemented, ResultStatus.NotImplemented, detail);

    public static ErrorResult BadGateway(string detail = FailureMessages.BadGateway)
        => new(ResultTitles.BadGateway, ResultStatus.BadGateway, detail);

    public static ErrorDataResult<T> BadGateway<T>(string detail = FailureMessages.BadGateway)
        => new(ResultTitles.BadGateway, ResultStatus.BadGateway, detail);

    public static ErrorResult ServiceUnavailable(string detail = FailureMessages.ServiceUnavailable)
        => new(ResultTitles.ServiceUnavailable, ResultStatus.ServiceUnavailable, detail);

    public static ErrorDataResult<T> ServiceUnavailable<T>(string detail = FailureMessages.ServiceUnavailable)
        => new(ResultTitles.ServiceUnavailable, ResultStatus.ServiceUnavailable, detail);

    public static ErrorResult GatewayTimeout(string detail = FailureMessages.GatewayTimeout)
        => new(ResultTitles.GatewayTimeout, ResultStatus.GatewayTimeout, detail);

    public static ErrorDataResult<T> GatewayTimeout<T>(string detail = FailureMessages.GatewayTimeout)
        => new(ResultTitles.GatewayTimeout, ResultStatus.GatewayTimeout, detail);

    public static ErrorResult HttpVersionNotSupported(string detail = FailureMessages.HttpVersionNotSupported)
        => new(ResultTitles.HttpVersionNotSupported, ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorDataResult<T> HttpVersionNotSupported<T>(string detail = FailureMessages.HttpVersionNotSupported)
        => new(ResultTitles.HttpVersionNotSupported, ResultStatus.HttpVersionNotSupported, detail);

    public static ErrorResult VariantAlsoNegotiates(string detail = FailureMessages.VariantAlsoNegotiates)
        => new(ResultTitles.VariantAlsoNegotiates, ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorDataResult<T> VariantAlsoNegotiates<T>(string detail = FailureMessages.VariantAlsoNegotiates)
        => new(ResultTitles.VariantAlsoNegotiates, ResultStatus.VariantAlsoNegotiates, detail);

    public static ErrorResult InsufficientStorage(string detail = FailureMessages.InsufficientStorage)
        => new(ResultTitles.InsufficientStorage, ResultStatus.InsufficientStorage, detail);

    public static ErrorDataResult<T> InsufficientStorage<T>(string detail = FailureMessages.InsufficientStorage)
        => new(ResultTitles.InsufficientStorage, ResultStatus.InsufficientStorage, detail);

    public static ErrorResult LoopDetected(string detail = FailureMessages.LoopDetected)
        => new(ResultTitles.LoopDetected, ResultStatus.LoopDetected, detail);

    public static ErrorDataResult<T> LoopDetected<T>(string detail = FailureMessages.LoopDetected)
        => new(ResultTitles.LoopDetected, ResultStatus.LoopDetected, detail);

    public static ErrorResult NotExtended(string detail = FailureMessages.NotExtended)
        => new(ResultTitles.NotExtended, ResultStatus.NotExtended, detail);

    public static ErrorDataResult<T> NotExtended<T>(string detail = FailureMessages.NotExtended)
        => new(ResultTitles.NotExtended, ResultStatus.NotExtended, detail);

    public static ErrorResult NetworkAuthenticationRequired(string detail = FailureMessages.NetworkAuthenticationRequired)
        => new(ResultTitles.NetworkAuthenticationRequired, ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorDataResult<T> NetworkAuthenticationRequired<T>(string detail = FailureMessages.NetworkAuthenticationRequired)
        => new(ResultTitles.NetworkAuthenticationRequired, ResultStatus.NetworkAuthenticationRequired, detail);

    public static ErrorResult Failure(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(string title, string detail, ResultStatus status)
        => new(title, status, detail);

    public static ErrorDataResult<T> Failure<T>(T data, string title, string detail, ResultStatus status)
        => new(data, title, status, detail);
}
