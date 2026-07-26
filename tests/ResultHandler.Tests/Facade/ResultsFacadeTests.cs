using ResultHandler.Core.Enums;
using Xunit;

namespace ResultHandler.Tests.Facade;

public class ResultsFacadeTests
{
    [Fact]
    public void Success_NoArgs_UsesDefaults()
    {
        var result = ResultHandler.Results.Success();

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
    }

    [Fact]
    public void Success_WithData_CarriesData()
    {
        var result = ResultHandler.Results.Success(42);

        Assert.True(result.IsSuccessful);
        Assert.Equal(42, result.Data);
    }

    [Fact]
    public void MovedPermanently_InterpolatesLocationIntoTitle()
    {
        var result = ResultHandler.Results.MovedPermanently("https://example.com/new");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.MovedPermanently, result.Status);
        Assert.Contains("https://example.com/new", result.Title);
    }

    [Fact]
    public void NotFound_UsesGivenDetail()
    {
        var result = ResultHandler.Results.NotFound("The user does not exist.");

        Assert.False(result.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Equal("The user does not exist.", result.Detail);
    }

    [Fact]
    public void Unauthorized_HasDefaultDetail()
    {
        var result = ResultHandler.Results.Unauthorized();

        Assert.Equal("Authentication is required to access this resource.", result.Detail);
    }

    [Fact]
    public void NotFoundOfT_ReturnsGenericErrorDataResult()
    {
        var result = ResultHandler.Results.NotFound<string>("Missing.");

        Assert.False(result.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Null(result.Data);
    }

    [Fact]
    public void Invalid_ParamsOverload_SetsErrors()
    {
        var result = ResultHandler.Results.Invalid("Name is required.", "Email is invalid.");

        Assert.Equal(ResultStatus.Invalid, result.Status);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public void Invalid_ReadOnlyListOverload_SetsErrors()
    {
        IReadOnlyList<string> errors = new[] { "Name is required." };

        var result = ResultHandler.Results.Invalid(errors);

        Assert.Equal(errors, result.Errors);
    }

    [Fact]
    public void Failure_EscapeHatch_BuildsCustomErrorResult()
    {
        var result = ResultHandler.Results.Failure("Custom title", "Custom detail", ResultStatus.Conflict);

        Assert.Equal("Custom title", result.Title);
        Assert.Equal("Custom detail", result.Detail);
        Assert.Equal(ResultStatus.Conflict, result.Status);
    }

    [Fact]
    public void FailureOfT_WithData_BuildsCustomErrorDataResult()
    {
        var result = ResultHandler.Results.Failure(-1, "Custom title", "Custom detail", ResultStatus.Conflict);

        Assert.Equal(-1, result.Data);
        Assert.Equal(ResultStatus.Conflict, result.Status);
    }
}
