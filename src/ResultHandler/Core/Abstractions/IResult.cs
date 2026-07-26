using System.Net;
using ResultHandler.Core.Enums;

namespace ResultHandler.Core.Abstractions;

/// <summary>
/// The outcome of an operation: whether it succeeded, a status mappable to an HTTP status code,
/// a short title, optional detail text, and an optional list of error messages.
/// </summary>
public interface IResult
{
    /// <summary>Whether the operation succeeded.</summary>
    bool IsSuccessful { get; }

    /// <summary>The outcome status, decoupled from <see cref="HttpStatusCode"/>; see <see cref="Mapping.ResultStatusExtensions.ToHttpStatusCode"/>.</summary>
    ResultStatus Status { get; }

    /// <summary>A short, human-readable summary of the result.</summary>
    string Title { get; }

    /// <summary>Optional additional context beyond <see cref="Title"/>.</summary>
    string? Detail { get; }

    /// <summary>Optional list of individual error messages (e.g. validation failures).</summary>
    IReadOnlyList<string> Errors { get; }

    /// <summary>Legacy alias for <see cref="Title"/>, kept for backward compatibility.</summary>
    [Obsolete("Use Title instead.")]
    string StatusMessage { get; }

    /// <summary>Legacy alias for <see cref="Status"/> as an <see cref="HttpStatusCode"/>, kept for backward compatibility.</summary>
    [Obsolete("Use Status instead.")]
    HttpStatusCode StatusCode { get; }
}
