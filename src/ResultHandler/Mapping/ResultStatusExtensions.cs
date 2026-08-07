using ResultHandler.Core.Enums;
using System.Net;

namespace ResultHandler.Mapping;

public static class ResultStatusExtensions
{
    public static HttpStatusCode ToHttpStatusCode(this ResultStatus status)
        => ResultStatusRegistry.ToHttpCode.TryGetValue(status, out var httpStatusCode)
            ? httpStatusCode
            : HttpStatusCode.InternalServerError;
}
