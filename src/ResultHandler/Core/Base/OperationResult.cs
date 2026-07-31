using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Mapping;
using ResultHandler.Serialization;
using System.Net;
using System.Text.Json.Serialization;

namespace ResultHandler.Core.Base;

/// <summary>
/// Base implementation of <see cref="IOperationResult"/>. Immutable; prefer the
/// <see cref="Implementations.Success.SuccessResult"/>/<see cref="Implementations.Error.ErrorResult"/>
/// subclasses or the <see cref="ResultHandler.Facade.Result"/> facade over constructing this directly.
/// </summary>
/// <param name="isSuccessful">Whether the operation succeeded.</param>
/// <param name="status">The outcome status.</param>
/// <param name="title">A short summary of the result.</param>
/// <param name="detail">Optional additional context.</param>
/// <param name="errors">Optional list of individual error messages.</param>
public class OperationResult(bool isSuccessful, ResultStatus status, string title, string? detail = null, IReadOnlyList<string>? errors = null)
    : IOperationResult, IFailureFactory<OperationResult>
{
    [JsonPropertyName("isSuccessful")]
    public virtual bool IsSuccessful { get; } = isSuccessful;

    [JsonConverter(typeof(ResultStatusJsonConverter))]
    [JsonPropertyName("statusCode")]
    public ResultStatus Status { get; } = status;

    [JsonPropertyName("statusMessage")]
    public string Title { get; } = title;

    [JsonPropertyName("detail")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Detail { get; } = detail;

    public IReadOnlyList<string> Errors { get; } = errors ?? [];

    /// <summary>Legacy constructor forwarding into the canonical constructor via <see cref="Mapping.HttpStatusCodeExtensions.ToResultStatus(HttpStatusCode)"/>.</summary>
    [Obsolete("Use OperationResult(bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public OperationResult(bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
        : this(isSuccessful, statusCode.ToResultStatus(), statusMessage)
    {
    }

    /// <summary>Legacy constructor with default title/status for the given success flag.</summary>
    [Obsolete("Use OperationResult(bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public OperationResult(bool isSuccessful)
        : this(
            isSuccessful,
            isSuccessful ? ResultStatus.Ok : ResultStatus.InternalServerError,
            isSuccessful ? "Operation completed successfully." : "An error occurred.")
    {
    }

    [Obsolete("Use Title instead.")]
    [JsonIgnore]
    public string StatusMessage => Title;

    [Obsolete("Use Status instead.")]
    [JsonIgnore]
    public HttpStatusCode StatusCode => Status.ToHttpStatusCode();

    public override bool Equals(object? obj)
        => obj is OperationResult other
            && IsSuccessful == other.IsSuccessful
            && Status == other.Status
            && Title == other.Title
            && Detail == other.Detail
            && (ReferenceEquals(Errors, other.Errors) || Errors.SequenceEqual(other.Errors));

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(IsSuccessful);
        hash.Add(Status);
        hash.Add(Title);
        hash.Add(Detail);
        foreach (var error in Errors)
        {
            hash.Add(error);
        }

        return hash.ToHashCode();
    }

    public override string ToString()
        => $"{Status} ({(int)Status.ToHttpStatusCode()}): {Title}";

    /// <inheritdoc />
    public static OperationResult Failure(IReadOnlyList<string> errors)
        => new ErrorResult("Validation Failed", ResultStatus.UnprocessableContent, errors);

    /// <inheritdoc />
    public static OperationResult Failure(string title, string detail, ResultStatus status)
        => new ErrorResult(title, status, detail);
}
