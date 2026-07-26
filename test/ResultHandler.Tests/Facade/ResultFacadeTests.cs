using ResultHandler.Core.Enums;
using ResultHandler.Facade;
using Xunit;

namespace ResultHandler.Tests.Facade;

public class ResultFacadeTests
{
    [Fact]
    public void Success_NoArgs_UsesDefaults()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
    }

    [Fact]
    public void Success_WithData_CarriesData()
    {
        var result = Result.Success(42);

        Assert.True(result.IsSuccessful);
        Assert.Equal(42, result.Data);
    }

    [Fact]
    public void MovedPermanently_InterpolatesLocationIntoTitle()
    {
        var result = Result.MovedPermanently("https://example.com/new");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.MovedPermanently, result.Status);
        Assert.Contains("https://example.com/new", result.Title);
    }

    [Fact]
    public void NotFound_UsesGivenDetail()
    {
        var result = Result.NotFound("The user does not exist.");

        Assert.False(result.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Equal("The user does not exist.", result.Detail);
    }

    [Fact]
    public void Unauthorized_HasDefaultDetail()
    {
        var result = Result.Unauthorized();

        Assert.Equal("Authentication is required to access this resource.", result.Detail);
    }

    [Fact]
    public void NotFoundOfT_ReturnsGenericErrorDataResult()
    {
        var result = Result.NotFound<string>("Missing.");

        Assert.False(result.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Invalid_ParamsOverload_SetsErrors()
    {
        var result = Result.Invalid("Name is required.", "Email is invalid.");

        Assert.Equal(ResultStatus.UnprocessableContent, result.Status);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public void Invalid_ReadOnlyListOverload_SetsErrors()
    {
        IReadOnlyList<string> errors = ["Name is required."];

        var result = Result.Invalid(errors);

        Assert.Equal(errors, result.Errors);
    }

    [Fact]
    public void Failure_EscapeHatch_BuildsCustomErrorResult()
    {
        var result = Result.Failure("Custom title", "Custom detail", ResultStatus.Conflict);

        Assert.Equal("Custom title", result.Title);
        Assert.Equal("Custom detail", result.Detail);
        Assert.Equal(ResultStatus.Conflict, result.Status);
    }

    [Fact]
    public void FailureOfT_WithData_BuildsCustomErrorDataResult()
    {
        var result = Result.Failure(-1, "Custom title", "Custom detail", ResultStatus.Conflict);

        Assert.Equal(-1, result.Data);
        Assert.Equal(ResultStatus.Conflict, result.Status);
    }
}
