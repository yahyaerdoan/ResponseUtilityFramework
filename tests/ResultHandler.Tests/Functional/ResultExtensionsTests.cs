using ResultHandler.Core.Enums;
using ResultHandler.Functional;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Functional;

public class ResultExtensionsTests
{
    [Fact]
    public void Match_Success_InvokesOnSuccess()
    {
        var result = new SuccessDataResult<int>(42, "Ok.", ResultStatus.Ok);

        var output = result.Match(data => $"got {data}", failure => "failed");

        Assert.Equal("got 42", output);
    }

    [Fact]
    public void Match_Failure_InvokesOnFailure()
    {
        var result = new ErrorDataResult<int>("Not found.", ResultStatus.NotFound);

        var output = result.Match(data => "success", failure => $"failed: {failure.Title}");

        Assert.Equal("failed: Not found.", output);
    }

    [Fact]
    public void OnSuccess_RunsAction_OnlyWhenSuccessful()
    {
        var ran = false;
        var success = new SuccessResult();
        var failure = new ErrorResult();

        success.OnSuccess(_ => ran = true);
        Assert.True(ran);

        ran = false;
        failure.OnSuccess(_ => ran = true);
        Assert.False(ran);
    }

    [Fact]
    public void OnFailure_RunsAction_OnlyWhenFailed()
    {
        var ran = false;
        var success = new SuccessResult();
        var failure = new ErrorResult();

        failure.OnFailure(_ => ran = true);
        Assert.True(ran);

        ran = false;
        success.OnFailure(_ => ran = true);
        Assert.False(ran);
    }

    [Fact]
    public void Map_Success_TransformsData()
    {
        var result = new SuccessDataResult<int>(2, "Ok.", ResultStatus.Ok);

        var mapped = result.Map(value => value * 10);

        Assert.True(mapped.IsSuccessful);
        Assert.Equal(20, mapped.Data);
    }

    [Fact]
    public void Map_Failure_PropagatesErrorWithoutInvokingMapper()
    {
        var result = new ErrorDataResult<int>("Not found.", ResultStatus.NotFound, "Missing.");

        var mapped = result.Map(value => value * 10);

        Assert.False(mapped.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, mapped.Status);
        Assert.Equal("Missing.", mapped.Detail);
    }

    [Fact]
    public void Bind_Success_ChainsIntoNextOperation()
    {
        var result = new SuccessDataResult<int>(2, "Ok.", ResultStatus.Ok);

        var chained = result.Bind(value => new SuccessDataResult<string>($"value={value}"));

        Assert.True(chained.IsSuccessful);
        Assert.Equal("value=2", chained.Data);
    }

    [Fact]
    public void Bind_Failure_ShortCircuitsWithoutInvokingBinder()
    {
        var result = new ErrorDataResult<int>("Not found.", ResultStatus.NotFound);
        var invoked = false;

        var chained = result.Bind(value =>
        {
            invoked = true;
            return new SuccessDataResult<string>("unused");
        });

        Assert.False(invoked);
        Assert.False(chained.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, chained.Status);
    }
}
