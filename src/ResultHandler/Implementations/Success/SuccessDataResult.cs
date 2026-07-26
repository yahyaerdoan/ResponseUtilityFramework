using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;
using System.Net;

namespace ResultHandler.Implementations.Success;

/// <summary>A successful <see cref="DataResult{T}"/> (<c>IsSuccessful</c> is always <see langword="true"/>).</summary>
public class SuccessDataResult<T> : DataResult<T>
{
    /// <summary>Success with the given data: status <see cref="ResultStatus.Ok"/>, title "Operation completed successfully.".</summary>
    public SuccessDataResult(T data)
        : base(data, true, ResultStatus.Ok, "Operation completed successfully.")
    {
    }

    public SuccessDataResult(T data, string title)
        : base(data, true, ResultStatus.Ok, title)
    {
    }

    public SuccessDataResult(T data, string title, ResultStatus status)
        : base(data, true, status, title)
    {
    }

    [Obsolete("Use SuccessDataResult(T data, string title, ResultStatus status) instead.")]
    public SuccessDataResult(T data, string statusMessage, HttpStatusCode statusCode)
        : base(data, true, statusCode.ToResultStatus(), statusMessage)
    {
    }
}
