using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;
using System.Net;

namespace ResultHandler.Implementations.Success;

/// <summary>A successful <see cref="OperationResult"/> (<c>IsSuccessful</c> is always <see langword="true"/>).</summary>
public class SuccessResult : OperationResult
{
    /// <summary>Default success: status <see cref="ResultStatus.Ok"/>, title "Operation completed successfully.".</summary>
    public SuccessResult()
        : base(true, ResultStatus.Ok, "Operation completed successfully.")
    {
    }

    public SuccessResult(string title)
        : base(true, ResultStatus.Ok, title)
    {
    }

    public SuccessResult(string title, ResultStatus status)
        : base(true, status, title)
    {
    }

    [Obsolete("Use SuccessResult(string title, ResultStatus status) instead.")]
    public SuccessResult(string statusMessage, HttpStatusCode statusCode)
        : base(true, statusCode.ToResultStatus(), statusMessage)
    {
    }
}
