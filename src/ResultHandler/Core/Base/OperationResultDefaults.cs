namespace ResultHandler.Core.Base;

/// <summary>
/// Single source of truth for the default title text shared by <see cref="OperationResult"/>,
/// <see cref="OperationDataResult{T}"/> and their success/error subclasses, so the parameterless
/// and legacy constructors across the hierarchy can never drift apart.
/// </summary>
internal static class OperationResultDefaults
{
    public const string SuccessTitle = "Operation completed successfully.";
    public const string ErrorTitle = "An error occurred.";
    public const string ValidationFailedTitle = "Validation Failed";
}
