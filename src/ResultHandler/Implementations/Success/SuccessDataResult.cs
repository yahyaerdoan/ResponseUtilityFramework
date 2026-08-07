using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;

namespace ResultHandler.Implementations.Success;

/// <summary>A successful <see cref="OperationDataResult{T}"/> (<c>IsSuccessful</c> is always <see langword="true"/>).</summary>
public class SuccessDataResult<T> : OperationDataResult<T>
{
    /// <summary>Success with the given data: status <see cref="ResultStatus.Ok"/>, title "Operation completed successfully.".</summary>
    public SuccessDataResult(T data)
        : base(data, true, ResultStatus.Ok, OperationResultDefaults.SuccessTitle)
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
}
