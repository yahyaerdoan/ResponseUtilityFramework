using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json.Serialization;
using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Mapping;

namespace ResultHandler.Core.Base;

/// <summary>
/// Base implementation of <see cref="IOperationResult{T}"/>. Immutable; prefer the
/// <see cref="Implementations.Success.SuccessDataResult{T}"/>/<see cref="Implementations.Error.ErrorDataResult{T}"/>
/// subclasses or the <see cref="ResultHandler.Facade.Result"/> facade over constructing this directly.
/// </summary>
/// <param name="data">The data payload; may be <see langword="null"/> when <paramref name="isSuccessful"/> is <see langword="false"/>.</param>
/// <param name="isSuccessful">Whether the operation succeeded.</param>
/// <param name="status">The outcome status.</param>
/// <param name="title">A short summary of the result.</param>
/// <param name="detail">Optional additional context.</param>
/// <param name="errors">Optional list of individual error messages.</param>
public class OperationDataResult<T>([AllowNull] T data, bool isSuccessful, ResultStatus status, string title, string? detail = null, IReadOnlyList<string>? errors = null)
    : OperationResult(isSuccessful, status, title, detail, errors), IOperationResult<T>, IResultFailureFactory<OperationDataResult<T>>
{
    /// <summary>Legacy constructor forwarding into the canonical constructor via <see cref="Mapping.HttpStatusCodeExtensions.ToResultStatus(HttpStatusCode)"/>.</summary>
    [Obsolete("Use OperationDataResult(T, bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public OperationDataResult([AllowNull] T resultData, bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
        : this(resultData, isSuccessful, statusCode.ToResultStatus(), statusMessage)
    {
    }

    /// <summary>Legacy constructor with default title/status for the given success flag.</summary>
    [Obsolete("Use OperationDataResult(T, bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public OperationDataResult([AllowNull] T resultData, bool isSuccessful)
        : this(
            resultData,
            isSuccessful,
            isSuccessful ? ResultStatus.Ok : ResultStatus.InternalServerError,
            isSuccessful ? OperationResultDefaults.SuccessTitle : OperationResultDefaults.ErrorTitle)
    {
    }

    /// <inheritdoc cref="IOperationResult{T}.Data"/>
    [MaybeNull]
    [JsonPropertyName("resultData")]
    public T Data { get; } = data!;

    /// <inheritdoc cref="IOperationResult.IsSuccessful"/>
    [JsonPropertyName("isSuccessful")]
    [MemberNotNullWhen(true, nameof(Data))]
    public override bool IsSuccessful => base.IsSuccessful;

    [Obsolete("Use Data instead.")]
    [MaybeNull]
    [JsonIgnore]
    public T ResultData => Data;

    /// <inheritdoc />
    public static new OperationDataResult<T> Failure(IReadOnlyList<string> errors)
        => new ErrorDataResult<T>(OperationResultDefaults.ValidationFailedTitle, ResultStatus.UnprocessableContent, errors);

    /// <inheritdoc />
    public static new OperationDataResult<T> Failure(string title, string detail, ResultStatus status)
        => new ErrorDataResult<T>(title, status, detail);

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (OperationDataResult<T>)obj;
        return base.Equals(other)
            && EqualityComparer<T>.Default.Equals(Data, other.Data);
    }

    public override int GetHashCode()
        => HashCode.Combine(base.GetHashCode(), Data);
}
