using ResultHandler.Core.Abstractions;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;

namespace ResultHandler.Functional;

/// <summary>
/// Functional-style composition helpers over <see cref="IOperationResult"/> and <see cref="IOperationResult{T}"/>.
/// Purely additive extension methods — they do not change the interfaces or existing constructors.
/// </summary>
public static class ResultExtensions
{
    /// <summary>Reduces a result into a single value depending on whether it succeeded.</summary>
    public static TOut Match<TOut>(this IOperationResult result, Func<IOperationResult, TOut> onSuccess, Func<IOperationResult, TOut> onFailure)
        => result.IsSuccessful ? onSuccess(result) : onFailure(result);

    /// <summary>Reduces a data result into a single value, exposing <see cref="IOperationResult{T}.Data"/> directly on success.</summary>
    public static TOut Match<T, TOut>(this IOperationResult<T> result, Func<T, TOut> onSuccess, Func<IOperationResult<T>, TOut> onFailure)
        => result.IsSuccessful ? onSuccess(result.Data) : onFailure(result);

    /// <summary>Runs a side effect when <paramref name="result"/> is successful and returns it unchanged, for fluent chaining.</summary>
    public static IOperationResult OnSuccess(this IOperationResult result, Action<IOperationResult> action)
    {
        if (result.IsSuccessful)
        {
            action(result);
        }

        return result;
    }

    /// <summary>Runs a side effect with the typed <see cref="IOperationResult{T}.Data"/> when <paramref name="result"/> is successful and returns it unchanged, for fluent chaining.</summary>
    public static IOperationResult<T> OnSuccess<T>(this IOperationResult<T> result, Action<T> action)
    {
        if (result.IsSuccessful)
        {
            action(result.Data);
        }

        return result;
    }

    /// <summary>Runs a side effect when <paramref name="result"/> failed and returns it unchanged, for fluent chaining.</summary>
    public static IOperationResult OnFailure(this IOperationResult result, Action<IOperationResult> action)
    {
        if (!result.IsSuccessful)
        {
            action(result);
        }

        return result;
    }

    /// <summary>Transforms the success payload, short-circuiting a failure into an equivalent <see cref="ErrorDataResult{T}"/>.</summary>
    public static IOperationResult<TOut> Map<T, TOut>(this IOperationResult<T> result, Func<T, TOut> mapper)
        => result.IsSuccessful
            ? new SuccessDataResult<TOut>(mapper(result.Data), result.Title, result.Status)
            : Propagate<TOut>(result);

    /// <summary>Chains into another result-returning operation, short-circuiting on failure.</summary>
    public static IOperationResult<TOut> Bind<T, TOut>(this IOperationResult<T> result, Func<T, IOperationResult<TOut>> binder)
        => result.IsSuccessful
            ? binder(result.Data)
            : Propagate<TOut>(result);

    /// <summary>
    /// Re-projects a failed, non-generic <see cref="IOperationResult"/> into the typed
    /// <see cref="ErrorDataResult{T}"/> envelope a caller must return.
    /// </summary>
    /// <param name="failed">
    /// A failed result, typically from a business-rule check that only knows <see cref="IOperationResult"/>,
    /// not the caller's final data type. Only call this when
    /// <paramref name="failed"/>.<see cref="IOperationResult.IsSuccessful"/> is <see langword="false"/>.
    /// </param>
    /// <typeparam name="T">The data type the caller's own result envelope needs to carry.</typeparam>
    /// <returns>
    /// An <see cref="ErrorDataResult{T}"/> carrying <paramref name="failed"/>'s title, status, detail
    /// and errors unchanged — only the shape changes, not the content.
    /// </returns>
    /// <example>
    /// <code>
    /// public async Task&lt;OperationDataResult&lt;CreatedBrandResponse&gt;&gt; Handle(CreateBrandCommand request, CancellationToken ct)
    /// {
    ///     var duplicateCheck = await _brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.Name);
    ///     if (!duplicateCheck.IsSuccessful)
    ///     {
    ///         return duplicateCheck.ToErrorDataResult&lt;CreatedBrandResponse&gt;();
    ///     }
    ///
    ///     // ...
    /// }
    /// </code>
    /// </example>
    public static ErrorDataResult<T> ToErrorDataResult<T>(this IOperationResult failed)
        => Propagate<T>(failed);

    private static ErrorDataResult<TOut> Propagate<TOut>(IOperationResult failed)
    {
        if (failed.Errors.Count > 0)
        {
            return new ErrorDataResult<TOut>(failed.Title, failed.Status, failed.Errors);
        }

        return failed.Detail is null
            ? new ErrorDataResult<TOut>(failed.Title, failed.Status)
            : new ErrorDataResult<TOut>(failed.Title, failed.Status, failed.Detail);
    }
}
