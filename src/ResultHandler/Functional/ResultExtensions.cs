using ResultHandler.Core.Abstractions;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;

namespace ResultHandler.Functional;

/// <summary>
/// Functional-style composition helpers over <see cref="IResult"/> and <see cref="IDataResult{T}"/>.
/// Purely additive extension methods — they do not change the interfaces or existing constructors.
/// </summary>
public static class ResultExtensions
{
    /// <summary>Reduces a result into a single value depending on whether it succeeded.</summary>
    public static TOut Match<TOut>(this IResult result, Func<IResult, TOut> onSuccess, Func<IResult, TOut> onFailure)
        => result.IsSuccessful ? onSuccess(result) : onFailure(result);

    /// <summary>Reduces a data result into a single value, exposing <see cref="IDataResult{T}.Data"/> directly on success.</summary>
    public static TOut Match<T, TOut>(this IDataResult<T> result, Func<T, TOut> onSuccess, Func<IDataResult<T>, TOut> onFailure)
        => result.IsSuccessful ? onSuccess(result.Data) : onFailure(result);

    /// <summary>Runs a side effect when <paramref name="result"/> is successful and returns it unchanged, for fluent chaining.</summary>
    public static IResult OnSuccess(this IResult result, Action<IResult> action)
    {
        if (result.IsSuccessful)
        {
            action(result);
        }

        return result;
    }

    /// <summary>Runs a side effect with the typed <see cref="IDataResult{T}.Data"/> when <paramref name="result"/> is successful and returns it unchanged, for fluent chaining.</summary>
    public static IDataResult<T> OnSuccess<T>(this IDataResult<T> result, Action<T> action)
    {
        if (result.IsSuccessful)
        {
            action(result.Data);
        }

        return result;
    }

    /// <summary>Runs a side effect when <paramref name="result"/> failed and returns it unchanged, for fluent chaining.</summary>
    public static IResult OnFailure(this IResult result, Action<IResult> action)
    {
        if (!result.IsSuccessful)
        {
            action(result);
        }

        return result;
    }

    /// <summary>Transforms the success payload, short-circuiting a failure into an equivalent <see cref="ErrorDataResult{T}"/>.</summary>
    public static IDataResult<TOut> Map<T, TOut>(this IDataResult<T> result, Func<T, TOut> mapper)
        => result.IsSuccessful
            ? new SuccessDataResult<TOut>(mapper(result.Data), result.Title, result.Status)
            : Propagate<TOut>(result);

    /// <summary>Chains into another result-returning operation, short-circuiting on failure.</summary>
    public static IDataResult<TOut> Bind<T, TOut>(this IDataResult<T> result, Func<T, IDataResult<TOut>> binder)
        => result.IsSuccessful
            ? binder(result.Data)
            : Propagate<TOut>(result);

    private static ErrorDataResult<TOut> Propagate<TOut>(IResult failed)
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
