using ResultHandler.Core.Abstractions;
using ResultHandler.Core.Base;
using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Success;
using Xunit;

namespace ResultHandler.Tests.Core;

public class OperationResultTests
{
    [Fact]
    public void OperationResult_ConstructedDirectly_ExposesGivenFields()
    {
        var result = new OperationResult(true, ResultStatus.Ok, "Done.", "Detail.");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal("Done.", result.Title);
        Assert.Equal("Detail.", result.Detail);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void OperationResult_AndEquivalentSubclass_AreNotEqual()
    {
        var bespoke = new OperationResult(true, ResultStatus.Ok, "Operation completed successfully.");
        var viaSubclass = new SuccessResult();

        Assert.NotEqual<object>(bespoke, viaSubclass);
    }

    [Fact]
    public void OperationDataResult_ConstructedDirectly_ExposesGivenFields()
    {
        var result = new OperationDataResult<int>(42, true, ResultStatus.Ok, "Done.");

        Assert.True(result.IsSuccessful);
        Assert.Equal(42, result.Data);
    }

    [Fact]
    public void OperationDataResult_AndEquivalentSubclass_AreNotEqual()
    {
        var bespoke = new OperationDataResult<int>(7, true, ResultStatus.Ok, "Fetched.");
        var viaSubclass = new SuccessDataResult<int>(7, "Fetched.");

        Assert.NotEqual<object>(bespoke, viaSubclass);
    }

    [Fact]
    public void IOperationResult_AsDeclaredType_ExposesInterfaceMembers()
    {
        IOperationResult result = new SuccessResult("All good.");

        Assert.True(result.IsSuccessful);
        Assert.Equal(ResultStatus.Ok, result.Status);
        Assert.Equal("All good.", result.Title);
    }

    [Fact]
    public void IOperationResultOfT_WhenSuccessful_DataIsNotNull()
    {
        IOperationResult<string> result = new SuccessDataResult<string>("payload");

        if (result.IsSuccessful)
        {
            Assert.NotNull(result.Data); // compiler-enforced via [MemberNotNullWhen(true, nameof(Data))]
        }
    }

    [Fact]
    public void Equals_WithSharedEmptyErrorsReference_ShortCircuitsWithoutEnumerating()
    {
        var a = new SuccessResult("Done.");
        var b = new SuccessResult("Done.");

        Assert.Same(a.Errors, b.Errors); // both fall back to the same Array.Empty<string>() instance
        Assert.Equal(a, b);
    }
}
