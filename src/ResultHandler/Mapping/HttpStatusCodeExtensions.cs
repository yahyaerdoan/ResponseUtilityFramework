using ResultHandler.Core.Enums;
using System.Net;

namespace ResultHandler.Mapping;

public static class HttpStatusCodeExtensions
{
    public static ResultStatus ToResultStatus(this HttpStatusCode httpStatusCode)
        => ((int)httpStatusCode).ToResultStatus();

    public static ResultStatus ToResultStatus(this int httpStatusCode)
    {
        if (ResultStatusRegistry.FromHttpCode.TryGetValue(httpStatusCode, out var status))
        {
            return status;
        }

        return httpStatusCode switch
        {
            >= 100 and < 200 => ResultStatus.Processing,
            >= 200 and < 300 => ResultStatus.Ok,
            >= 300 and < 400 => ResultStatus.Found,
            >= 400 and < 500 => ResultStatus.BadRequest,
            _ => ResultStatus.Error,
        };
    }
}
