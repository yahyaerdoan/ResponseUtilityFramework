using System.Net;
using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;

namespace ResultHandler.Implementations.Error;

/// <summary>A failed <see cref="OperationDataResult{T}"/> (<c>IsSuccessful</c> is always <see langword="false"/>).</summary>
public class ErrorDataResult<T> : OperationDataResult<T>
{
    /// <summary>Default error, no data: status <see cref="ResultStatus.InternalServerError"/>, title "An error occurred.".</summary>
    public ErrorDataResult()
        : base(default, false, ResultStatus.InternalServerError, OperationResultDefaults.ErrorTitle)
    {
    }

    public ErrorDataResult(T data)
        : base(data, false, ResultStatus.InternalServerError, OperationResultDefaults.ErrorTitle)
    {
    }

    public ErrorDataResult(string title, ResultStatus status)
        : base(default, false, status, title)
    {
    }

    public ErrorDataResult(string title, ResultStatus status, string detail)
        : base(default, false, status, title, detail)
    {
    }

    public ErrorDataResult(string title, ResultStatus status, IReadOnlyList<string> errors)
        : base(default, false, status, title, null, errors)
    {
    }

    public ErrorDataResult(T data, string title, ResultStatus status)
        : base(data, false, status, title)
    {
    }

    public ErrorDataResult(T data, string title, ResultStatus status, string detail)
        : base(data, false, status, title, detail)
    {
    }

    [Obsolete("Use ErrorDataResult(string title, ResultStatus status) instead.")]
    public ErrorDataResult(string statusMessage, HttpStatusCode statusCode)
        : base(default, false, statusCode.ToResultStatus(), statusMessage)
    {
    }

    [Obsolete("Use ErrorDataResult(string title, ResultStatus status, string detail) instead.")]
    public ErrorDataResult(string statusMessage, HttpStatusCode statusCode, string detail)
        : base(default, false, statusCode.ToResultStatus(), statusMessage, detail)
    {
    }

    [Obsolete("Use ErrorDataResult(T data, string title, ResultStatus status) instead.")]
    public ErrorDataResult(T resultData, string statusMessage, HttpStatusCode statusCode)
        : base(resultData, false, statusCode.ToResultStatus(), statusMessage)
    {
    }

    [Obsolete("Use ErrorDataResult(T data, string title, ResultStatus status, string detail) instead.")]
    public ErrorDataResult(T resultData, string statusMessage, HttpStatusCode statusCode, string detail)
        : base(resultData, false, statusCode.ToResultStatus(), statusMessage, detail)
    {
    }
}
