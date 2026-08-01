using System.Net;
using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;

namespace ResultHandler.Implementations.Error;

/// <summary>A failed <see cref="OperationResult"/> (<c>IsSuccessful</c> is always <see langword="false"/>).</summary>
public class ErrorResult : OperationResult
{
    /// <summary>Default error: status <see cref="ResultStatus.InternalServerError"/>, title "An error occurred.".</summary>
    public ErrorResult()
        : base(false, ResultStatus.InternalServerError, OperationResultDefaults.ErrorTitle)
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
