using ResultHandler.Core.Abstractions;
using ResultHandler.Facade;
using ResultHandler.Implementations.Error;

namespace ResultHandler.Functional;

/// <summary>
/// Named, per-status shortcuts over <see cref="IFailureFactory{TSelf}.Failure(string, string, ResultHandler.Core.Enums.ResultStatus)"/> —
/// written once, generically, for every implementer of <see cref="IFailureFactory{TSelf}"/>.
/// </summary>
/// <remarks>
/// Each shortcut delegates to the matching <see cref="Result"/> facade method and re-projects its
/// <see cref="ErrorResult"/> into the caller's generic result type, so titles and default messages
/// have exactly one source of truth: <see cref="Result"/> itself.
/// </remarks>
/// <example>
/// Use these from generic code that only has a type parameter to work with (a MediatR pipeline
/// behavior, in this example) — everyday code with a concrete result type should call
/// <see cref="Result"/> directly instead (see its own documentation):
/// <code>
/// public class AuthorizationBehavior&lt;TRequest, TResponse&gt;(ICurrentUser user)
///     : IPipelineBehavior&lt;TRequest, TResponse&gt;
///     where TRequest : IRequest&lt;TResponse&gt;, IRequireRole
///     where TResponse : IOperationResult, IFailureFactory&lt;TResponse&gt;
/// {
///     public async Task&lt;TResponse&gt; Handle(TRequest request, RequestHandlerDelegate&lt;TResponse&gt; next, CancellationToken ct)
///     {
///         if (!user.IsAuthenticated)
///         {
///             return ResultFailure.Unauthorized&lt;TResponse&gt;();
///         }
///
///         if (!user.IsInRole(request.RequiredRole))
///         {
///             return ResultFailure.Forbidden&lt;TResponse&gt;();
///         }
///
///         return await next(ct);
///     }
/// }
/// </code>
/// </example>
public static class ResultFailure
{
    public static TSelf BadRequest<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.BadRequest(detail));

    public static TSelf Unauthorized<TSelf>(string detail = "Authentication is required to access this resource.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.Unauthorized(detail));

    public static TSelf PaymentRequired<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.PaymentRequired(detail));

    public static TSelf Forbidden<TSelf>(string detail = "You do not have permission to access this resource.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.Forbidden(detail));

    public static TSelf NotFound<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.NotFound(detail));

    public static TSelf MethodNotAllowed<TSelf>(string detail = "The HTTP method used is not allowed for this endpoint.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.MethodNotAllowed(detail));

    public static TSelf NotAcceptable<TSelf>(string detail = "The requested media type is not supported by this server.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.NotAcceptable(detail));

    public static TSelf ProxyAuthenticationRequired<TSelf>(string detail = "Proxy authentication is required to access this resource.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.ProxyAuthenticationRequired(detail));

    public static TSelf RequestTimeout<TSelf>(string detail = "The request timed out. Please try again.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.RequestTimeout(detail));

    public static TSelf Conflict<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.Conflict(detail));

    public static TSelf Gone<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.Gone(detail));

    public static TSelf LengthRequired<TSelf>(string detail = "A Content-Length header is required for this request.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.LengthRequired(detail));

    public static TSelf PreconditionFailed<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.PreconditionFailed(detail));

    public static TSelf ContentTooLarge<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.ContentTooLarge(detail));

    public static TSelf UriTooLong<TSelf>(string detail = "The request URI exceeds the maximum allowed length.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.UriTooLong(detail));

    public static TSelf UnsupportedMediaType<TSelf>(string detail = "The submitted media type is not supported. Please use a supported type.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.UnsupportedMediaType(detail));

    public static TSelf RangeNotSatisfiable<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.RangeNotSatisfiable(detail));

    public static TSelf ExpectationFailed<TSelf>(string detail = "The expectation given in the Expect header could not be met.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.ExpectationFailed(detail));

    public static TSelf ImATeapot<TSelf>(string detail = "I'm a teapot.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.ImATeapot(detail));

    public static TSelf MisdirectedRequest<TSelf>(string detail = "The request was directed to a server unable to produce a response.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.MisdirectedRequest(detail));

    public static TSelf UnprocessableContent<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.UnprocessableContent(detail));

    public static TSelf Locked<TSelf>(string detail = "The resource is currently locked and cannot be modified.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.Locked(detail));

    public static TSelf FailedDependency<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.FailedDependency(detail));

    public static TSelf TooEarly<TSelf>(string detail = "The request was rejected because it may be replayed.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.TooEarly(detail));

    public static TSelf UpgradeRequired<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.UpgradeRequired(detail));

    public static TSelf PreconditionRequired<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.PreconditionRequired(detail));

    public static TSelf TooManyRequests<TSelf>(string detail = "Too many requests. Please slow down and try again later.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.TooManyRequests(detail));

    public static TSelf RequestHeaderFieldsTooLarge<TSelf>(string detail = "One or more request header fields exceed the maximum allowed size.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.RequestHeaderFieldsTooLarge(detail));

    public static TSelf UnavailableForLegalReasons<TSelf>(string detail) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.UnavailableForLegalReasons(detail));

    public static TSelf InternalServerError<TSelf>(string detail = "An unexpected error occurred. Please try again later.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.InternalServerError(detail));

    public static TSelf NotImplemented<TSelf>(string detail = "This feature is not yet implemented.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.NotImplemented(detail));

    public static TSelf BadGateway<TSelf>(string detail = "An upstream server returned an invalid response.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.BadGateway(detail));

    public static TSelf ServiceUnavailable<TSelf>(string detail = "The service is temporarily unavailable. Please try again later.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.ServiceUnavailable(detail));

    public static TSelf GatewayTimeout<TSelf>(string detail = "An upstream server did not respond in time.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.GatewayTimeout(detail));

    public static TSelf HttpVersionNotSupported<TSelf>(string detail = "The HTTP version used in the request is not supported.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.HttpVersionNotSupported(detail));

    public static TSelf VariantAlsoNegotiates<TSelf>(string detail = "The server has an internal configuration error.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.VariantAlsoNegotiates(detail));

    public static TSelf InsufficientStorage<TSelf>(string detail = "Insufficient storage to complete the request.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.InsufficientStorage(detail));

    public static TSelf LoopDetected<TSelf>(string detail = "The server detected an infinite loop while processing the request.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.LoopDetected(detail));

    public static TSelf NotExtended<TSelf>(string detail = "Further extensions to the request are required.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.NotExtended(detail));

    public static TSelf NetworkAuthenticationRequired<TSelf>(string detail = "Network authentication is required to access this resource.") where TSelf : IOperationResult, IFailureFactory<TSelf>
        => From<TSelf>(Result.NetworkAuthenticationRequired(detail));

    /// <summary>Re-projects a concrete <see cref="ErrorResult"/> produced by the <see cref="Result"/> facade into <typeparamref name="TSelf"/>.</summary>
    private static TSelf From<TSelf>(ErrorResult error) where TSelf : IOperationResult, IFailureFactory<TSelf>
        => TSelf.Failure(error.Title, error.Detail ?? error.Title, error.Status);
}
