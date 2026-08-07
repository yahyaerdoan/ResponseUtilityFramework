using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;

namespace ResultHandler.Implementations.Success;

/// <summary>A successful <see cref="OperationResult"/> (<c>IsSuccessful</c> is always <see langword="true"/>).</summary>
public class SuccessResult : OperationResult
{
    /// <summary>Default success: status <see cref="ResultStatus.Ok"/>, title "Operation completed successfully.".</summary>
    public SuccessResult()
        : base(true, ResultStatus.Ok, OperationResultDefaults.SuccessTitle)
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
}
