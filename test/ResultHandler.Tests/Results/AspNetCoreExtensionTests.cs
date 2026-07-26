using Microsoft.AspNetCore.Mvc;
using ResultHandler.AspNetCore.Extensions;
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Results;

public class AspNetCoreExtensionTests
{
    [Fact]
    public void ToActionResult_Success_NoContent_ReturnsNoContentResult()
    {
        var result = new SuccessResult("Deleted.", ResultStatus.NoContent);

        var actionResult = result.ToActionResult();

        Assert.IsType<NoContentResult>(actionResult);
    }

    [Fact]
    public void ToActionResult_Success_NotModified_Returns304()
    {
        var result = new SuccessResult("Not modified.", ResultStatus.NotModified);

        var actionResult = Assert.IsType<StatusCodeResult>(result.ToActionResult());

        Assert.Equal(304, actionResult.StatusCode);
    }

    [Fact]
    public void ToActionResult_Success_Ok_ReturnsStatusCodeResultWithoutBody()
    {
        var result = new SuccessResult("Ok.", ResultStatus.Ok);

        var actionResult = Assert.IsType<StatusCodeResult>(result.ToActionResult());

        Assert.Equal(200, actionResult.StatusCode);
    }

    [Fact]
    public void ToActionResultOfT_Success_ReturnsBodyWithData()
    {
        var result = new SuccessDataResult<string>("hello", "Ok.", ResultStatus.Ok);

        var actionResult = Assert.IsType<OkObjectResult>(result.ToActionResult());

        Assert.Equal("hello", actionResult.Value);
        Assert.Equal(200, actionResult.StatusCode);
    }

    [Fact]
    public void ToActionResult_Failure_ReturnsProblemDetailsObjectResult()
    {
        var result = new ErrorResult("Not found.", ResultStatus.NotFound, "The user does not exist.");

        var actionResult = Assert.IsType<ObjectResult>(result.ToActionResult());
        var problemDetails = Assert.IsType<ProblemDetails>(actionResult.Value);

        Assert.Equal(404, actionResult.StatusCode);
        Assert.Equal(404, problemDetails.Status);
        Assert.Equal("Not found.", problemDetails.Title);
        Assert.Equal("The user does not exist.", problemDetails.Detail);
    }

    [Fact]
    public void ToProblemDetails_WithErrors_AddsErrorsExtension()
    {
        var errors = new[] { "Field A is required." };
        var result = new ErrorResult("Validation failed.", ResultStatus.UnprocessableContent, errors);

        var problemDetails = result.ToProblemDetails();

        Assert.True(problemDetails.Extensions.ContainsKey("errors"));
        Assert.Equal(errors, problemDetails.Extensions["errors"]);
    }

    [Fact]
    public void ToProblemDetails_UnmappedStatus_FallsBackToAboutBlank()
    {
        var result = new SuccessResult("Ok.", ResultStatus.Ok);

        var problemDetails = result.ToProblemDetails();

        Assert.Equal("about:blank", problemDetails.Type);
    }

    [Fact]
    public void ToEnvelopedActionResult_Success_WrapsWholeResult()
    {
        var result = new SuccessDataResult<int>(42, "Fetched.", ResultStatus.Ok);

        var actionResult = Assert.IsType<OkObjectResult>(result.ToEnvelopedActionResult());

        Assert.Same(result, actionResult.Value);
        Assert.Equal(200, actionResult.StatusCode);
    }
}
