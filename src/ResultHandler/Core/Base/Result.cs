using System.Net;
using System.Text.Json.Serialization;
using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;
using ResultHandler.Serialization;

namespace ResultHandler.Core.Base;

/// <summary>
/// Base implementation of <see cref="IResult"/>. Immutable; prefer the
/// <see cref="Implementations.Success.SuccessResult"/>/<see cref="Implementations.Error.ErrorResult"/>
/// subclasses or the <see cref="Results"/> facade over constructing this directly.
/// </summary>
/// <param name="isSuccessful">Whether the operation succeeded.</param>
/// <param name="status">The outcome status.</param>
/// <param name="title">A short summary of the result.</param>
/// <param name="detail">Optional additional context.</param>
/// <param name="errors">Optional list of individual error messages.</param>
public class Result(bool isSuccessful, ResultStatus status, string title, string? detail = null, IReadOnlyList<string>? errors = null) : IResult
{
    public virtual bool IsSuccessful { get; } = isSuccessful;

    [JsonConverter(typeof(ResultStatusJsonConverter))]
    [JsonPropertyName("statusCode")]
    public ResultStatus Status { get; } = status;

    [JsonPropertyName("statusMessage")]
    public string Title { get; } = title;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Detail { get; } = detail;

    public IReadOnlyList<string> Errors { get; } = errors ?? [];

    /// <summary>Legacy constructor forwarding into the canonical constructor via <see cref="Mapping.HttpStatusCodeExtensions.ToResultStatus(HttpStatusCode)"/>.</summary>
    [Obsolete("Use Result(bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public Result(bool isSuccessful, string statusMessage, HttpStatusCode statusCode)
        : this(isSuccessful, statusCode.ToResultStatus(), statusMessage)
    {
    }

    /// <summary>Legacy constructor with default title/status for the given success flag.</summary>
    [Obsolete("Use Result(bool, ResultStatus, string, string?, IReadOnlyList<string>?) instead.")]
    public Result(bool isSuccessful)
        : this(
            isSuccessful,
            isSuccessful ? ResultStatus.Ok : ResultStatus.Error,
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
        => obj is Result other
            && IsSuccessful == other.IsSuccessful
            && Status == other.Status
            && Title == other.Title
            && Detail == other.Detail
            && Errors.SequenceEqual(other.Errors);

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
}
