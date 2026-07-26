namespace ResultHandler.Facade;

/// <summary>
/// Static factory facade over <see cref="ResultHandler.Implementations.Success.SuccessResult"/>,
/// <see cref="ResultHandler.Implementations.Success.SuccessDataResult{T}"/>,
/// <see cref="ResultHandler.Implementations.Error.ErrorResult"/> and
/// <see cref="ResultHandler.Implementations.Error.ErrorDataResult{T}"/>.
/// <para>
/// One factory pair per <see cref="ResultHandler.Core.Enums.ResultStatus"/> that makes sense to construct
/// directly (non-generic for a bodyless/void outcome, generic <c>&lt;T&gt;</c> for one that
/// carries data), named after the status (e.g. <c>Result.NotFound(...)</c>). Success factories
/// live in <c>Result.Success.cs</c>, error factories and the <c>Failure</c> escape hatches live
/// in <c>Result.Error.cs</c> — split for readability only, this remains a single logical facade.
/// </para>
/// </summary>
public static partial class Result
{
    // touch: verify beta publish pipeline (retest after push-step fix)
}
