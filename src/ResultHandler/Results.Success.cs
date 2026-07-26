using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Success;

namespace ResultHandler;

public static partial class Results
{
    public static SuccessResult Continue(string title = "Continue.")
        => new(title, ResultStatus.Continue);

    public static SuccessResult SwitchingProtocols(string title = "Switching protocols.")
        => new(title, ResultStatus.SwitchingProtocols);

    public static SuccessResult Processing(string title = "Processing.")
        => new(title, ResultStatus.Processing);

    public static SuccessResult EarlyHints(string title = "Early hints.")
        => new(title, ResultStatus.EarlyHints);

    public static SuccessResult Success()
        => new();

    public static SuccessResult Success(string title)
        => new(title);

    public static SuccessResult Created(string title = "Resource created successfully.")
        => new(title, ResultStatus.Created);

    public static SuccessResult Accepted(string title = "Request accepted for processing.")
        => new(title, ResultStatus.Accepted);

    public static SuccessResult NoContent()
        => new("No content.", ResultStatus.NoContent);

    public static SuccessResult ResetContent()
        => new("Reset content.", ResultStatus.ResetContent);

    public static SuccessDataResult<T> Success<T>(T data)
        => new(data);

    public static SuccessDataResult<T> Success<T>(T data, string title)
        => new(data, title);

    public static SuccessDataResult<T> Created<T>(T data, string title = "Resource created successfully.")
        => new(data, title, ResultStatus.Created);

    public static SuccessDataResult<T> Accepted<T>(T data, string title = "Request accepted for processing.")
        => new(data, title, ResultStatus.Accepted);

    public static SuccessDataResult<T> NonAuthoritativeInformation<T>(T data, string title = "Non-authoritative information.")
        => new(data, title, ResultStatus.NonAuthoritativeInformation);

    public static SuccessDataResult<T> PartialContent<T>(T data, string title = "Partial content.")
        => new(data, title, ResultStatus.PartialContent);

    public static SuccessDataResult<T> MultiStatus<T>(T data, string title = "Multi-status.")
        => new(data, title, ResultStatus.MultiStatus);

    public static SuccessDataResult<T> AlreadyReported<T>(T data, string title = "Already reported.")
        => new(data, title, ResultStatus.AlreadyReported);

    public static SuccessDataResult<T> ImUsed<T>(T data, string title = "IM used.")
        => new(data, title, ResultStatus.ImUsed);

    public static SuccessResult MultipleChoices(string detail)
        => new(detail, ResultStatus.MultipleChoices);

    public static SuccessResult MovedPermanently(string location)
        => new($"Resource moved permanently to: {location}", ResultStatus.MovedPermanently);

    public static SuccessResult Found(string location)
        => new($"Resource found at: {location}", ResultStatus.Found);

    public static SuccessResult SeeOther(string location)
        => new($"See other resource at: {location}", ResultStatus.SeeOther);

    public static SuccessResult UseProxy(string proxy)
        => new($"Requested resource must be accessed through the proxy: {proxy}", ResultStatus.UseProxy);

    public static SuccessResult NotModified()
        => new("Not modified.", ResultStatus.NotModified);

    public static SuccessResult TemporaryRedirect(string location)
        => new($"Temporarily redirected to: {location}", ResultStatus.TemporaryRedirect);

    public static SuccessResult PermanentRedirect(string location)
        => new($"Permanently redirected to: {location}", ResultStatus.PermanentRedirect);
}
