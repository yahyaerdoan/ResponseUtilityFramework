using System.Net;
using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;

namespace ResultHandler.Implementations.Error;

/// <summary>A failed <see cref="Result"/> (<c>IsSuccessful</c> is always <see langword="false"/>).</summary>
public class ErrorResult : Result
{
    /// <summary>Default error: status <see cref="ResultStatus.Error"/>, title "An error occurred.".</summary>
    public ErrorResult()
        : base(false, ResultStatus.Error, "An error occurred.")
    {
    }

    public ErrorResult(string title, ResultStatus status)
        : base(false, status, title)
    {
    }

    public ErrorResult(string title, ResultStatus status, string detail)
        : base(false, status, title, detail)
    {
    }

    public ErrorResult(string title, ResultStatus status, IReadOnlyList<string> errors)
        : base(false, status, title, null, errors)
    {
    }

    [Obsolete("Use ErrorResult(string title, ResultStatus status) instead.")]
    public ErrorResult(string statusMessage, HttpStatusCode statusCode)
        : base(false, statusCode.ToResultStatus(), statusMessage)
    {
    }

    [Obsolete("Use ErrorResult(string title, ResultStatus status, string detail) instead.")]
    public ErrorResult(string statusMessage, HttpStatusCode statusCode, string detail)
        : base(false, statusCode.ToResultStatus(), statusMessage, detail)
    {
    }
}
