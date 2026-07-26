using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json.Serialization;

namespace ResultHandler.Core.Base;

/// <summary>
/// Base implementation of <see cref="IOperationResult{T}"/>. Immutable; prefer the
/// <see cref="Implementations.Success.SuccessDataResult{T}"/>/<see cref="Implementations.Error.ErrorDataResult{T}"/>
/// subclasses or the <see cref="ResultHandler.Facade.Results"/> facade over constructing this directly.
/// </summary>
/// <param name="data">The data payload; may be <see langword="null"/> when <paramref name="isSuccessful"/> is <see langword="false"/>.</param>
/// <param name="isSuccessful">Whether the operation succeeded.</param>
/// <param name="status">The outcome status.</param>
/// <param name="title">A short summary of the result.</param>
/// <param name="detail">Optional additional context.</param>
/// <param name="errors">Optional list of individual error messages.</param>
public class DataResult<T>([AllowNull] T data, bool isSuccessful, ResultStatus status, string title, string? detail = null, IReadOnlyList<string>? errors = null)
    : Result(isSuccessful, status, title, detail, errors), IOperationResult<T>
{
    /// <inheritdoc cref="IOperationResult{T}.Data"/>
    [MaybeNull]
    [JsonPropertyName("resultData")]
    public T Data { get; } = data!;

    /// <inheritdoc cref="IOperationResult.IsSuccessful"/>
    [JsonPropertyName("isSuccessful")]
    [MemberNotNullWhen(true, nameof(Data))]
    public override bool IsSuccessful => base.IsSuccessful;

    /// <summary>Legacy constructor forwarding into the canonical constructor via <see cref="Mapping.HttpStatusCodeExtensions.ToResultStatus(HttpStatusCode)"/>.</summary>
    [Obsolete("Use DataResult(T, bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public DataResult([AllowNull] T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
        : this(resultData, isSuccessful, statusCode.ToResultStatus(), statusMessage)
    {
    }

    /// <summary>Legacy constructor with default title/status for the given success flag.</summary>
    [Obsolete("Use DataResult(T, bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public DataResult([AllowNull] T resultData, bool isSuccessful)
        : this(
            resultData,
            isSuccessful,
            isSuccessful ? ResultStatus.Ok : ResultStatus.Error,
            isSuccessful ? "Operation completed successfully." : "An error occurred.")
    {
    }

    [Obsolete("Use Data instead.")]
    [MaybeNull]
    [JsonIgnore]
    public T ResultData => Data;

    public override bool Equals(object? obj)
        => obj is DataResult<T> other
            && base.Equals(other)
            && EqualityComparer<T>.Default.Equals(Data!, other.Data!);

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Data);
}
