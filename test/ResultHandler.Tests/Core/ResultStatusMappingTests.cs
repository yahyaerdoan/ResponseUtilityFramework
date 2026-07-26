using ResultHandler.Core.Enums;
using ResultHandler.Mapping;
using Xunit;

namespace ResultHandler.Tests.Core;

public class ResultStatusMappingTests
{
    public static TheoryData<ResultStatus> AllStatuses
    {
        get
        {
            var data = new TheoryData<ResultStatus>();
            foreach (var status in Enum.GetValues<ResultStatus>())
            {
                data.Add(status);
            }

            return data;
        }
    }

    [Theory]
    [MemberData(nameof(AllStatuses))]
    public void ToHttpStatusCode_Then_ToResultStatus_RoundTrips(ResultStatus status)
    {
        var httpStatusCode = status.ToHttpStatusCode();
        var roundTripped = httpStatusCode.ToResultStatus();

        Assert.Equal(status, roundTripped);
    }

    [Fact]
    public void FromHttpCode_IsDerivedFromToHttpCode_WithNoCollisions()
    {
        Assert.Equal(ResultStatusRegistry.ToHttpCode.Count, ResultStatusRegistry.FromHttpCode.Count);

        foreach (var (status, httpStatusCode) in ResultStatusRegistry.ToHttpCode)
        {
            Assert.True(ResultStatusRegistry.FromHttpCode.TryGetValue((int)httpStatusCode, out var mappedBack));
            Assert.Equal(status, mappedBack);
        }
    }

    [Theory]
    [InlineData(200, ResultStatus.Ok)]
    [InlineData(404, ResultStatus.NotFound)]
    [InlineData(500, ResultStatus.Error)]
    public void IntToResultStatus_UsesRegistryLookup(int httpCode, ResultStatus expected)
        => Assert.Equal(expected, httpCode.ToResultStatus());

    [Theory]
    [InlineData(299, ResultStatus.Ok)]
    [InlineData(499, ResultStatus.BadRequest)]
    [InlineData(599, ResultStatus.Error)]
    [InlineData(999, ResultStatus.Error)]
    public void IntToResultStatus_FallsBackToRangeBasedSwitch_WhenNotInRegistry(int httpCode, ResultStatus expected)
        => Assert.Equal(expected, httpCode.ToResultStatus());
}
