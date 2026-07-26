using ResultHandler.Core.Enums;
using System.Net;

namespace ResultHandler.Mapping;

internal static class ResultStatusRegistry
{
    public static readonly IReadOnlyDictionary<ResultStatus, HttpStatusCode> ToHttpCode = new Dictionary<ResultStatus, HttpStatusCode>
    {
        // 1xx
        [ResultStatus.Continue] = HttpStatusCode.Continue,
        [ResultStatus.SwitchingProtocols] = HttpStatusCode.SwitchingProtocols,
        [ResultStatus.Processing] = (HttpStatusCode)102,
        [ResultStatus.EarlyHints] = (HttpStatusCode)103,

        // 2xx
        [ResultStatus.Ok] = HttpStatusCode.OK,
        [ResultStatus.Created] = HttpStatusCode.Created,
        [ResultStatus.Accepted] = HttpStatusCode.Accepted,
        [ResultStatus.NonAuthoritativeInformation] = HttpStatusCode.NonAuthoritativeInformation,
        [ResultStatus.NoContent] = HttpStatusCode.NoContent,
        [ResultStatus.ResetContent] = HttpStatusCode.ResetContent,
        [ResultStatus.PartialContent] = HttpStatusCode.PartialContent,
        [ResultStatus.MultiStatus] = (HttpStatusCode)207,
        [ResultStatus.AlreadyReported] = (HttpStatusCode)208,
        [ResultStatus.ImUsed] = (HttpStatusCode)226,

        // 3xx
        [ResultStatus.MultipleChoices] = HttpStatusCode.MultipleChoices,
        [ResultStatus.MovedPermanently] = HttpStatusCode.MovedPermanently,
        [ResultStatus.Found] = HttpStatusCode.Found,
        [ResultStatus.SeeOther] = HttpStatusCode.SeeOther,
        [ResultStatus.NotModified] = HttpStatusCode.NotModified,
        [ResultStatus.UseProxy] = HttpStatusCode.UseProxy,
        [ResultStatus.TemporaryRedirect] = HttpStatusCode.TemporaryRedirect,
        [ResultStatus.PermanentRedirect] = (HttpStatusCode)308,

        // 4xx
        [ResultStatus.BadRequest] = HttpStatusCode.BadRequest,
        [ResultStatus.Unauthorized] = HttpStatusCode.Unauthorized,
        [ResultStatus.PaymentRequired] = HttpStatusCode.PaymentRequired,
        [ResultStatus.Forbidden] = HttpStatusCode.Forbidden,
        [ResultStatus.NotFound] = HttpStatusCode.NotFound,
        [ResultStatus.MethodNotAllowed] = HttpStatusCode.MethodNotAllowed,
        [ResultStatus.NotAcceptable] = HttpStatusCode.NotAcceptable,
        [ResultStatus.ProxyAuthenticationRequired] = HttpStatusCode.ProxyAuthenticationRequired,
        [ResultStatus.RequestTimeout] = HttpStatusCode.RequestTimeout,
        [ResultStatus.Conflict] = HttpStatusCode.Conflict,
        [ResultStatus.Gone] = HttpStatusCode.Gone,
        [ResultStatus.LengthRequired] = HttpStatusCode.LengthRequired,
        [ResultStatus.PreconditionFailed] = HttpStatusCode.PreconditionFailed,
        [ResultStatus.ContentTooLarge] = HttpStatusCode.RequestEntityTooLarge,
        [ResultStatus.UriTooLong] = HttpStatusCode.RequestUriTooLong,
        [ResultStatus.UnsupportedMediaType] = HttpStatusCode.UnsupportedMediaType,
        [ResultStatus.RangeNotSatisfiable] = HttpStatusCode.RequestedRangeNotSatisfiable,
        [ResultStatus.ExpectationFailed] = HttpStatusCode.ExpectationFailed,
        [ResultStatus.ImATeapot] = (HttpStatusCode)418,
        [ResultStatus.MisdirectedRequest] = (HttpStatusCode)421,
        [ResultStatus.Invalid] = (HttpStatusCode)422,
        [ResultStatus.Locked] = (HttpStatusCode)423,
        [ResultStatus.FailedDependency] = (HttpStatusCode)424,
        [ResultStatus.TooEarly] = (HttpStatusCode)425,
        [ResultStatus.UpgradeRequired] = (HttpStatusCode)426,
        [ResultStatus.PreconditionRequired] = (HttpStatusCode)428,
        [ResultStatus.TooManyRequests] = (HttpStatusCode)429,
        [ResultStatus.RequestHeaderFieldsTooLarge] = (HttpStatusCode)431,
        [ResultStatus.UnavailableForLegalReasons] = (HttpStatusCode)451,

        // 5xx
        [ResultStatus.Error] = HttpStatusCode.InternalServerError,
        [ResultStatus.NotImplemented] = HttpStatusCode.NotImplemented,
        [ResultStatus.BadGateway] = HttpStatusCode.BadGateway,
        [ResultStatus.Unavailable] = HttpStatusCode.ServiceUnavailable,
        [ResultStatus.GatewayTimeout] = HttpStatusCode.GatewayTimeout,
        [ResultStatus.HttpVersionNotSupported] = HttpStatusCode.HttpVersionNotSupported,
        [ResultStatus.VariantAlsoNegotiates] = (HttpStatusCode)506,
        [ResultStatus.InsufficientStorage] = (HttpStatusCode)507,
        [ResultStatus.LoopDetected] = (HttpStatusCode)508,
        [ResultStatus.NotExtended] = (HttpStatusCode)510,
        [ResultStatus.NetworkAuthenticationRequired] = (HttpStatusCode)511,
    };

    // Never hand-written: always derived from ToHttpCode so the two directions can never drift apart.
    public static readonly IReadOnlyDictionary<int, ResultStatus> FromHttpCode =
        ToHttpCode.ToDictionary(kv => (int)kv.Value, kv => kv.Key);
}
