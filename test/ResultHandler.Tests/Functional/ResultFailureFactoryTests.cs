using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Functional;
using Xunit;

namespace ResultHandler.Tests.Functional;

public class ResultFailureFactoryTests
{
    [Fact]
    public void NotFound_ReprojectsIntoGenericTSelf_WithMatchingTitleStatusAndDetail()
    {
        var failure = ResultFailureFactory.NotFound<OperationResult>("Product 42 does not exist.");

        Assert.False(failure.IsSuccessful);
        Assert.Equal(ResultStatus.NotFound, failure.Status);
        Assert.Equal("Not Found", failure.Title);
        Assert.Equal("Product 42 does not exist.", failure.Detail);
    }

    [Fact]
    public void Unauthorized_WithoutDetail_UsesSameDefaultAsResultFacade()
    {
        var fromFactory = ResultFailureFactory.Unauthorized<OperationResult>();
        var fromFacade = ResultHandler.Facade.Result.Unauthorized();

        Assert.Equal(fromFacade.Detail, fromFactory.Detail);
        Assert.Equal(ResultStatus.Unauthorized, fromFactory.Status);
    }

    [Fact]
    public void Conflict_ReprojectsIntoGenericDataTSelf()
    {
        var failure = ResultFailureFactory.Conflict<OperationDataResult<int>>("Already exists.");

        Assert.False(failure.IsSuccessful);
        Assert.Equal(ResultStatus.Conflict, failure.Status);
        Assert.Equal("Already exists.", failure.Detail);
    }
}
