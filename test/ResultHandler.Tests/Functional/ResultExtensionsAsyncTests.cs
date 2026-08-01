using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Enums;
using ResultHandler.Functional;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Functional;

public class ResultExtensionsAsyncTests
{
    [Fact]
    public async Task MatchAsync_TaskSource_Success_InvokesOnSuccess()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new SuccessDataResult<int>(42, "Ok.", ResultStatus.Ok));

        var output = await resultTask.MatchAsync(data => $"got {data}", failure => "failed");

        Assert.Equal("got 42", output);
    }

    [Fact]
    public async Task MatchAsync_TaskSource_Failure_InvokesOnFailure()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new ErrorDataResult<int>("Not found.", ResultStatus.NotFound));

        var output = await resultTask.MatchAsync(data => "success", failure => $"failed: {failure.Title}");

        Assert.Equal("failed: Not found.", output);
    }

    [Fact]
    public async Task OnSuccessAsync_SyncSourceAsyncAction_RunsOnlyWhenSuccessful()
    {
        var ran = false;
        IOperationResult<int> success = new SuccessDataResult<int>(42, "Ok.", ResultStatus.Ok);
        IOperationResult<int> failure = new ErrorDataResult<int>("Not found.", ResultStatus.NotFound);

        await success.OnSuccessAsync(_ =>
        {
            ran = true;
            return Task.CompletedTask;
        });
        Assert.True(ran);

        ran = false;
        await failure.OnSuccessAsync(_ =>
        {
            ran = true;
            return Task.CompletedTask;
        });
        Assert.False(ran);
    }

    [Fact]
    public async Task OnFailureAsync_TaskSource_RunsOnlyWhenFailed()
    {
        var ran = false;
        var successTask = Task.FromResult<IOperationResult>(new SuccessResult());
        var failureTask = Task.FromResult<IOperationResult>(new ErrorResult());

        await failureTask.OnFailureAsync(_ => ran = true);
        Assert.True(ran);

        ran = false;
        await successTask.OnFailureAsync(_ => ran = true);
        Assert.False(ran);
    }

    [Fact]
    public async Task MapAsync_TaskSource_AsyncMapper_TransformsData()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new SuccessDataResult<int>(2, "Ok.", ResultStatus.Ok));

        var mapped = await resultTask.MapAsync(value => Task.FromResult(value * 10));

        Assert.True(mapped.IsSuccessful);
        Assert.Equal(20, mapped.Data);
    }

    [Fact]
    public async Task MapAsync_Failure_PropagatesErrorWithoutInvokingMapper()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new ErrorDataResult<int>("Not found.", ResultStatus.NotFound, "Missing."));
        var invoked = false;

        var mapped = await resultTask.MapAsync(value =>
        {
            invoked = true;
            return Task.FromResult(value * 10);
        });

        Assert.False(invoked);
        Assert.False(mapped.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, mapped.Status);
        Assert.Equal("Missing.", mapped.Detail);
    }

    [Fact]
    public async Task BindAsync_TaskSource_AsyncBinder_ChainsIntoNextOperation()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new SuccessDataResult<int>(2, "Ok.", ResultStatus.Ok));

        var chained = await resultTask.BindAsync(value => Task.FromResult<IOperationResult<string>>(new SuccessDataResult<string>($"value={value}")));

        Assert.True(chained.IsSuccessful);
        Assert.Equal("value=2", chained.Data);
    }

    [Fact]
    public async Task BindAsync_Failure_ShortCircuitsWithoutInvokingBinder()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new ErrorDataResult<int>("Not found.", ResultStatus.NotFound));
        var invoked = false;

        var chained = await resultTask.BindAsync(value =>
        {
            invoked = true;
            return Task.FromResult<IOperationResult<string>>(new SuccessDataResult<string>("unused"));
        });

        Assert.False(invoked);
        Assert.False(chained.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, chained.Status);
    }

    [Fact]
    public async Task EnsureAsync_TaskSource_SyncPredicateFails_ReturnsValidationFailure()
    {
        var resultTask = Task.FromResult<IOperationResult<int>>(new SuccessDataResult<int>(-5, "Ok.", ResultStatus.Ok));

        var ensured = await resultTask.EnsureAsync(value => value > 0, "Value must be positive.");

        Assert.False(ensured.IsSuccessful);
        Assert.Equal(ResultStatus.UnprocessableContent, ensured.Status);
        Assert.Equal("Value must be positive.", ensured.Detail);
    }

    [Fact]
    public async Task EnsureAsync_SyncSourceAsyncPredicate_PassesThrough()
    {
        IOperationResult<int> result = new SuccessDataResult<int>(5, "Ok.", ResultStatus.Ok);

        var ensured = await result.EnsureAsync(value => Task.FromResult(value > 0), "Value must be positive.");

        Assert.Same(result, ensured);
    }

    [Fact]
    public async Task EnsureAsync_TaskSourceAsyncPredicateFails_ShortCircuitsChain()
    {
        var chained = await GetOrderTotalAsync()
            .EnsureAsync(total => Task.FromResult(total > 0), "Order total must be positive.")
            .MapAsync(total => $"total={total}");

        Assert.False(chained.IsSuccessful);
        Assert.Equal(ResultStatus.UnprocessableContent, chained.Status);

        static Task<IOperationResult<decimal>> GetOrderTotalAsync()
            => Task.FromResult<IOperationResult<decimal>>(new SuccessDataResult<decimal>(-1m, "Ok.", ResultStatus.Ok));
    }

    [Fact]
    public async Task FluentChain_MapAsyncThenBindAsync_ComposesAcrossAwaitsWithoutIntermediateAwait()
    {
        var chained = await GetUserIdAsync()
            .MapAsync(id => $"user-{id}")
            .BindAsync(name => ValidateAsync(name));

        Assert.True(chained.IsSuccessful);
        Assert.Equal("user-7", chained.Data);

        static Task<IOperationResult<int>> GetUserIdAsync()
            => Task.FromResult<IOperationResult<int>>(new SuccessDataResult<int>(7, "Ok.", ResultStatus.Ok));

        static Task<IOperationResult<string>> ValidateAsync(string name)
            => Task.FromResult<IOperationResult<string>>(new SuccessDataResult<string>(name));
    }
}
