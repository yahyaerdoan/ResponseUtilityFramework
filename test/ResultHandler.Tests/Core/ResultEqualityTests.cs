using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Core;

public class ResultEqualityTests
{
    [Fact]
    public void TwoResultsWithSameFields_AreEqual()
    {
        var a = new ErrorResult("Not found.", ResultStatus.NotFound, "Missing.");
        var b = new ErrorResult("Not found.", ResultStatus.NotFound, "Missing.");

        Assert.Equal(a, b);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void TwoResultsWithDifferentDetail_AreNotEqual()
    {
        var a = new ErrorResult("Not found.", ResultStatus.NotFound, "Missing A.");
        var b = new ErrorResult("Not found.", ResultStatus.NotFound, "Missing B.");

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void TwoDataResultsWithSameData_AreEqual()
    {
        var a = new SuccessDataResult<int>(42, "Fetched.", ResultStatus.Ok);
        var b = new SuccessDataResult<int>(42, "Fetched.", ResultStatus.Ok);

        Assert.Equal(a, b);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void TwoDataResultsWithDifferentData_AreNotEqual()
    {
        var a = new SuccessDataResult<int>(1, "Fetched.", ResultStatus.Ok);
        var b = new SuccessDataResult<int>(2, "Fetched.", ResultStatus.Ok);

        Assert.NotEqual(a, b);
    }

    [Fact]
    public void ToString_IncludesStatusHttpCodeAndTitle()
    {
        var result = new ErrorResult("Not found.", ResultStatus.NotFound);

        Assert.Equal("NotFound (404): Not found.", result.ToString());
    }
}
