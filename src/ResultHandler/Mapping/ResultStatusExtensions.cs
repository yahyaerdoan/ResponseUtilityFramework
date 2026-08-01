using System.Net;
using ResultHandler.Core.Enums;

namespace ResultHandler.Mapping;

public static class ResultStatusExtensions
{
    public static HttpStatusCode ToHttpStatusCode(this ResultStatus status)
        => ResultStatusRegistry.ToHttpCode.TryGetValue(status, out var httpStatusCode)
            ? httpStatusCode
            : HttpStatusCode.InternalServerError;
}
