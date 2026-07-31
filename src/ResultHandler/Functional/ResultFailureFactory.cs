using ResultHandler.Core.Abstractions;
using ResultHandler.Facade;
using ResultHandler.Implementations.Error;

namespace ResultHandler.Functional;

/// <summary>
/// Named, per-status shortcuts over <see cref="IResultFailureFactory{TSelf}.Failure(string, string, ResultHandler.Core.Enums.ResultStatus)"/> —
/// written once, generically, for every implementer of <see cref="IResultFailureFactory{TSelf}"/>.
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
///     where TResponse : IOperationResult, IResultFailureFactory&lt;TResponse&gt;
/// {
///     public async Task&lt;TResponse&gt; Handle(TRequest request, RequestHandlerDelegate&lt;TResponse&gt; next, CancellationToken ct)
///     {
///         if (!user.IsAuthenticated)
///         {
///             return ResultFailureFactory.Unauthorized&lt;TResponse&gt;();
///         }
///
///         if (!user.IsInRole(request.RequiredRole))
///         {
///             return ResultFailureFactory.Forbidden&lt;TResponse&gt;();
///         }
///
///         return await next(ct);
///     }
/// }
/// </code>
/// </example>
public static class ResultFailureFactory
{
    public static TSelf BadRequest<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.BadRequest(detail));

    public static TSelf Unauthorized<TSelf>(string detail = FailureMessages.Unauthorized) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.Unauthorized(detail));

    public static TSelf PaymentRequired<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.PaymentRequired(detail));

    public static TSelf Forbidden<TSelf>(string detail = FailureMessages.Forbidden) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.Forbidden(detail));

    public static TSelf NotFound<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.NotFound(detail));

    public static TSelf MethodNotAllowed<TSelf>(string detail = FailureMessages.MethodNotAllowed) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.MethodNotAllowed(detail));

    public static TSelf NotAcceptable<TSelf>(string detail = FailureMessages.NotAcceptable) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.NotAcceptable(detail));

    public static TSelf ProxyAuthenticationRequired<TSelf>(string detail = FailureMessages.ProxyAuthenticationRequired) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.ProxyAuthenticationRequired(detail));

    public static TSelf RequestTimeout<TSelf>(string detail = FailureMessages.RequestTimeout) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.RequestTimeout(detail));

    public static TSelf Conflict<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.Conflict(detail));

    public static TSelf Gone<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.Gone(detail));

    public static TSelf LengthRequired<TSelf>(string detail = FailureMessages.LengthRequired) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.LengthRequired(detail));

    public static TSelf PreconditionFailed<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.PreconditionFailed(detail));

    public static TSelf ContentTooLarge<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.ContentTooLarge(detail));

    public static TSelf UriTooLong<TSelf>(string detail = FailureMessages.UriTooLong) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.UriTooLong(detail));

    public static TSelf UnsupportedMediaType<TSelf>(string detail = FailureMessages.UnsupportedMediaType) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.UnsupportedMediaType(detail));

    public static TSelf RangeNotSatisfiable<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.RangeNotSatisfiable(detail));

    public static TSelf ExpectationFailed<TSelf>(string detail = FailureMessages.ExpectationFailed) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.ExpectationFailed(detail));

    public static TSelf ImATeapot<TSelf>(string detail = FailureMessages.ImATeapot) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.ImATeapot(detail));

    public static TSelf MisdirectedRequest<TSelf>(string detail = FailureMessages.MisdirectedRequest) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.MisdirectedRequest(detail));

    public static TSelf UnprocessableContent<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.UnprocessableContent(detail));

    public static TSelf Locked<TSelf>(string detail = FailureMessages.Locked) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.Locked(detail));

    public static TSelf FailedDependency<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.FailedDependency(detail));

    public static TSelf TooEarly<TSelf>(string detail = FailureMessages.TooEarly) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.TooEarly(detail));

    public static TSelf UpgradeRequired<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.UpgradeRequired(detail));

    public static TSelf PreconditionRequired<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.PreconditionRequired(detail));

    public static TSelf TooManyRequests<TSelf>(string detail = FailureMessages.TooManyRequests) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.TooManyRequests(detail));

    public static TSelf RequestHeaderFieldsTooLarge<TSelf>(string detail = FailureMessages.RequestHeaderFieldsTooLarge) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.RequestHeaderFieldsTooLarge(detail));

    public static TSelf UnavailableForLegalReasons<TSelf>(string detail) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.UnavailableForLegalReasons(detail));

    public static TSelf InternalServerError<TSelf>(string detail = FailureMessages.InternalServerError) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.InternalServerError(detail));

    public static TSelf NotImplemented<TSelf>(string detail = FailureMessages.NotImplemented) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.NotImplemented(detail));

    public static TSelf BadGateway<TSelf>(string detail = FailureMessages.BadGateway) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.BadGateway(detail));

    public static TSelf ServiceUnavailable<TSelf>(string detail = FailureMessages.ServiceUnavailable) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.ServiceUnavailable(detail));

    public static TSelf GatewayTimeout<TSelf>(string detail = FailureMessages.GatewayTimeout) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.GatewayTimeout(detail));

    public static TSelf HttpVersionNotSupported<TSelf>(string detail = FailureMessages.HttpVersionNotSupported) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.HttpVersionNotSupported(detail));

    public static TSelf VariantAlsoNegotiates<TSelf>(string detail = FailureMessages.VariantAlsoNegotiates) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.VariantAlsoNegotiates(detail));

    public static TSelf InsufficientStorage<TSelf>(string detail = FailureMessages.InsufficientStorage) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.InsufficientStorage(detail));

    public static TSelf LoopDetected<TSelf>(string detail = FailureMessages.LoopDetected) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.LoopDetected(detail));

    public static TSelf NotExtended<TSelf>(string detail = FailureMessages.NotExtended) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.NotExtended(detail));

    public static TSelf NetworkAuthenticationRequired<TSelf>(string detail = FailureMessages.NetworkAuthenticationRequired) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => From<TSelf>(Result.NetworkAuthenticationRequired(detail));

    /// <summary>Re-projects a concrete <see cref="ErrorResult"/> produced by the <see cref="Result"/> facade into <typeparamref name="TSelf"/>.</summary>
    private static TSelf From<TSelf>(ErrorResult error) where TSelf : IOperationResult, IResultFailureFactory<TSelf>
        => TSelf.Failure(error.Title, error.Detail ?? error.Title, error.Status);
}
