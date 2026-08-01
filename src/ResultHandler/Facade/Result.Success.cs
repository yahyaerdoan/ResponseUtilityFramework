using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Success;

namespace ResultHandler.Facade;

public static partial class Result
{
    public static SuccessResult Continue(string title = ResultTitles.Continue)
        => new(title, ResultStatus.Continue);

    public static SuccessResult SwitchingProtocols(string title = ResultTitles.SwitchingProtocols)
        => new(title, ResultStatus.SwitchingProtocols);

    public static SuccessResult Processing(string title = ResultTitles.Processing)
        => new(title, ResultStatus.Processing);

    public static SuccessResult EarlyHints(string title = ResultTitles.EarlyHints)
        => new(title, ResultStatus.EarlyHints);

    public static SuccessResult Success()
        => new();

    public static SuccessResult Success(string title)
        => new(title);

    public static SuccessDataResult<T> Success<T>(T data)
        => new(data);

    public static SuccessDataResult<T> Success<T>(T data, string title)
        => new(data, title);

    public static SuccessResult Created(string title = ResultTitles.Created)
        => new(title, ResultStatus.Created);

    public static SuccessDataResult<T> Created<T>(T data, string title = ResultTitles.Created)
        => new(data, title, ResultStatus.Created);

    public static SuccessResult Accepted(string title = ResultTitles.Accepted)
        => new(title, ResultStatus.Accepted);

    public static SuccessDataResult<T> Accepted<T>(T data, string title = ResultTitles.Accepted)
        => new(data, title, ResultStatus.Accepted);

    public static SuccessResult NoContent()
        => new(ResultTitles.NoContent, ResultStatus.NoContent);

    public static SuccessResult ResetContent()
        => new(ResultTitles.ResetContent, ResultStatus.ResetContent);

    public static SuccessResult NonAuthoritativeInformation()
        => new(ResultTitles.NonAuthoritativeInformation, ResultStatus.NonAuthoritativeInformation);

    public static SuccessDataResult<T> NonAuthoritativeInformation<T>(T data, string title = ResultTitles.NonAuthoritativeInformation)
        => new(data, title, ResultStatus.NonAuthoritativeInformation);

    public static SuccessResult PartialContent()
        => new(ResultTitles.PartialContent, ResultStatus.PartialContent);

    public static SuccessDataResult<T> PartialContent<T>(T data, string title = ResultTitles.PartialContent)
        => new(data, title, ResultStatus.PartialContent);

    public static SuccessResult MultiStatus()
        => new(ResultTitles.MultiStatus, ResultStatus.MultiStatus);

    public static SuccessDataResult<T> MultiStatus<T>(T data, string title = ResultTitles.MultiStatus)
        => new(data, title, ResultStatus.MultiStatus);

    public static SuccessResult AlreadyReported()
        => new(ResultTitles.AlreadyReported, ResultStatus.AlreadyReported);

    public static SuccessDataResult<T> AlreadyReported<T>(T data, string title = ResultTitles.AlreadyReported)
        => new(data, title, ResultStatus.AlreadyReported);

    public static SuccessResult ImUsed()
        => new(ResultTitles.ImUsed, ResultStatus.ImUsed);

    public static SuccessDataResult<T> ImUsed<T>(T data, string title = ResultTitles.ImUsed)
        => new(data, title, ResultStatus.ImUsed);

    public static SuccessResult MultipleChoices(string detail)
        => new(detail, ResultStatus.MultipleChoices);

    public static SuccessDataResult<T> MultipleChoices<T>(T data, string detail)
        => new(data, detail, ResultStatus.MultipleChoices);

    public static SuccessResult MovedPermanently(string location)
        => new(string.Format(ResultTitles.MovedPermanentlyTemplate, location), ResultStatus.MovedPermanently);

    public static SuccessDataResult<T> MovedPermanently<T>(T data, string location)
        => new(data, string.Format(ResultTitles.MovedPermanentlyTemplate, location), ResultStatus.MovedPermanently);

    public static SuccessResult Found(string location)
        => new(string.Format(ResultTitles.FoundTemplate, location), ResultStatus.Found);

    public static SuccessDataResult<T> Found<T>(T data, string location)
        => new(data, string.Format(ResultTitles.FoundTemplate, location), ResultStatus.Found);

    public static SuccessResult SeeOther(string location)
        => new(string.Format(ResultTitles.SeeOtherTemplate, location), ResultStatus.SeeOther);

    public static SuccessDataResult<T> SeeOther<T>(T data, string location)
        => new(data, string.Format(ResultTitles.SeeOtherTemplate, location), ResultStatus.SeeOther);

    public static SuccessResult UseProxy(string proxy)
        => new(string.Format(ResultTitles.UseProxyTemplate, proxy), ResultStatus.UseProxy);

    public static SuccessDataResult<T> UseProxy<T>(T data, string proxy)
        => new(data, string.Format(ResultTitles.UseProxyTemplate, proxy), ResultStatus.UseProxy);

    public static SuccessResult NotModified()
        => new(ResultTitles.NotModified, ResultStatus.NotModified);

    public static SuccessDataResult<T> NotModified<T>(T data)
        => new(data, ResultTitles.NotModified, ResultStatus.NotModified);

    public static SuccessResult TemporaryRedirect(string location)
        => new(string.Format(ResultTitles.TemporaryRedirectTemplate, location), ResultStatus.TemporaryRedirect);

    public static SuccessDataResult<T> TemporaryRedirect<T>(T data, string location)
        => new(data, string.Format(ResultTitles.TemporaryRedirectTemplate, location), ResultStatus.TemporaryRedirect);

    public static SuccessResult PermanentRedirect(string location)
        => new(string.Format(ResultTitles.PermanentRedirectTemplate, location), ResultStatus.PermanentRedirect);

    public static SuccessDataResult<T> PermanentRedirect<T>(T data, string location)
        => new(data, string.Format(ResultTitles.PermanentRedirectTemplate, location), ResultStatus.PermanentRedirect);
}
