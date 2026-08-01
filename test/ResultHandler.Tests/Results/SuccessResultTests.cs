using System.Net;
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Results;

public class SuccessResultTests
{
    [Fact]
    public void DefaultConstructor_SetsExpectedDefaults()
    {
        var result = new SuccessResult();

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal("Operation completed successfully.", result.Title);
    }

    [Fact]
    public void TitleConstructor_KeepsDefaultStatus()
    {
        var result = new SuccessResult("Custom title.");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal("Custom title.", result.Title);
    }

    [Fact]
    public void TitleStatusConstructor_SetsBothFields()
    {
        var result = new SuccessResult("Created.", ResultStatus.Created);

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Created, result.Status);
        Assert.Equal("Created.", result.Title);
    }

#pragma warning disable CS0618
    [Fact]
    public void ObsoleteConstructor_ForwardsIntoNewApi()
    {
        var result = new SuccessResult("Legacy success.", HttpStatusCode.Created);

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Created, result.Status);
        Assert.Equal("Legacy success.", result.StatusMessage);
        Assert.Equal(HttpStatusCode.Created, result.StatusCode);
    }
#pragma warning restore CS0618

    [Fact]
    public void SuccessDataResult_DataOnlyConstructor_UsesDefaultTitleAndStatus()
    {
        var result = new SuccessDataResult<string>("payload");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal("Operation completed successfully.", result.Title);
        Assert.Equal("payload", result.Data);
    }

    [Fact]
    public void SuccessDataResult_DataTitleStatusConstructor_SetsAllFields()
    {
        var result = new SuccessDataResult<int>(42, "Fetched.", ResultStatus.Ok);

        Assert.Equal(42, result.Data);
        Assert.Equal("Fetched.", result.Title);
        Assert.Equal(ResultStatus.Ok, result.Status);
    }
}
