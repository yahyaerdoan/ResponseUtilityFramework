using System.Diagnostics.CodeAnalysis;

namespace ResultHandler.Core.Abstractions;

/// <summary>Extends <see cref="IOperationResult"/> with a data payload of type <typeparamref name="T"/>.</summary>
public interface IOperationResult<T> : IOperationResult
{
    /// <summary>The data returned by the operation; guaranteed non-null when <see cref="IsSuccessful"/> is <see langword="true"/>.</summary>
    [MaybeNull]
    T Data { get; }

    /// <inheritdoc cref="IOperationResult.IsSuccessful"/>
    [MemberNotNullWhen(true, nameof(Data))]
    new bool IsSuccessful { get; }
}
