using System.Diagnostics.CodeAnalysis;

namespace ResultHandler.Core.Abstractions;

/// <summary>Extends <see cref="IResult"/> with a data payload of type <typeparamref name="T"/>.</summary>
public interface IDataResult<T> : IResult
{
    /// <summary>The data returned by the operation; guaranteed non-null when <see cref="IsSuccessful"/> is <see langword="true"/>.</summary>
    [MaybeNull]
    T Data { get; }

    /// <inheritdoc cref="IResult.IsSuccessful"/>
    [MemberNotNullWhen(true, nameof(Data))]
    new bool IsSuccessful { get; }

    /// <summary>Legacy alias for <see cref="Data"/>, kept for backward compatibility.</summary>
    [Obsolete("Use Data instead.")]
    [MaybeNull]
    T ResultData { get; }
}
