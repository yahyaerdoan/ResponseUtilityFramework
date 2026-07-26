using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Success;

namespace ResultHandler;

public static partial class Results
{
    public static SuccessResult Continue(string title = "Continue.")
    {
        return new SuccessResult(title, ResultStatus.Continue);
    }

    public static SuccessResult SwitchingProtocols(string title = "Switching protocols.")
    {
        return new SuccessResult(title, ResultStatus.SwitchingProtocols);
    }

    public static SuccessResult Processing(string title = "Processing.")
    {
        return new SuccessResult(title, ResultStatus.Processing);
    }

    public static SuccessResult EarlyHints(string title = "Early hints.")
    {
        return new SuccessResult(title, ResultStatus.EarlyHints);
    }

    public static SuccessResult Success()
    {
        return new SuccessResult();
    }

    public static SuccessResult Success(string title)
    {
        return new SuccessResult(title);
    }

    public static SuccessResult Created(string title = "Resource created successfully.")
    {
        return new SuccessResult(title, ResultStatus.Created);
    }

    public static SuccessResult Accepted(string title = "Request accepted for processing.")
    {
        return new SuccessResult(title, ResultStatus.Accepted);
    }

    public static SuccessResult NoContent()
    {
        return new SuccessResult("No content.", ResultStatus.NoContent);
    }

    public static SuccessResult ResetContent()
    {
        return new SuccessResult("Reset content.", ResultStatus.ResetContent);
    }

    public static SuccessDataResult<T> Success<T>(T data)
    {
        return new SuccessDataResult<T>(data);
    }

    public static SuccessDataResult<T> Success<T>(T data, string title)
    {
        return new SuccessDataResult<T>(data, title);
    }

    public static SuccessDataResult<T> Created<T>(T data, string title = "Resource created successfully.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.Created);
    }

    public static SuccessDataResult<T> Accepted<T>(T data, string title = "Request accepted for processing.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.Accepted);
    }

    public static SuccessDataResult<T> NonAuthoritativeInformation<T>(T data, string title = "Non-authoritative information.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.NonAuthoritativeInformation);
    }

    public static SuccessDataResult<T> PartialContent<T>(T data, string title = "Partial content.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.PartialContent);
    }

    public static SuccessDataResult<T> MultiStatus<T>(T data, string title = "Multi-status.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.MultiStatus);
    }

    public static SuccessDataResult<T> AlreadyReported<T>(T data, string title = "Already reported.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.AlreadyReported);
    }

    public static SuccessDataResult<T> ImUsed<T>(T data, string title = "IM used.")
    {
        return new SuccessDataResult<T>(data, title, ResultStatus.ImUsed);
    }

    public static SuccessResult MultipleChoices(string detail)
    {
        return new SuccessResult(detail, ResultStatus.MultipleChoices);
    }

    public static SuccessResult MovedPermanently(string location)
    {
        return new SuccessResult($"Resource moved permanently to: {location}", ResultStatus.MovedPermanently);
    }

    public static SuccessResult Found(string location)
    {
        return new SuccessResult($"Resource found at: {location}", ResultStatus.Found);
    }

    public static SuccessResult SeeOther(string location)
    {
        return new SuccessResult($"See other resource at: {location}", ResultStatus.SeeOther);
    }

    public static SuccessResult NotModified()
    {
        return new SuccessResult("Not modified.", ResultStatus.NotModified);
    }

    public static SuccessResult TemporaryRedirect(string location)
    {
        return new SuccessResult($"Temporarily redirected to: {location}", ResultStatus.TemporaryRedirect);
    }

    public static SuccessResult PermanentRedirect(string location)
    {
        return new SuccessResult($"Permanently redirected to: {location}", ResultStatus.PermanentRedirect);
    }
}
