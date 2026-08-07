using ResultHandler.Core.Enums;
using ResultHandler.Implementations.Error;
using ResultHandler.Implementations.Success;
using ResultHandler.Mapping;
using System.Text.Json;
using Xunit;

namespace ResultHandler.Tests.Core;

public class SerializationTests
{
    [Fact]
    public void SuccessDataResult_SerializesWithExpectedPropertyNames()
    {
        var result = new SuccessDataResult<string>("payload", "Fetched.", ResultStatus.Ok);

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(result));
        var root = document.RootElement;

        Assert.Equal((int)ResultStatus.Ok.ToHttpStatusCode(), root.GetProperty("statusCode").GetInt32());
        Assert.Equal("Fetched.", root.GetProperty("statusMessage").GetString());
        Assert.Equal("payload", root.GetProperty("resultData").GetString());
        Assert.True(root.GetProperty("isSuccessful").GetBoolean());
    }

    [Fact]
    public void Detail_IsOmittedFromJson_WhenNull()
    {
        var result = new ErrorResult("Bad Request", ResultStatus.BadRequest);

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(result));

        Assert.False(document.RootElement.TryGetProperty("detail", out _));
    }

    [Fact]
    public void Detail_IsIncludedInJson_WhenSet()
    {
        var result = new ErrorResult("Bad Request", ResultStatus.BadRequest, "Field X is missing.");

        using var document = JsonDocument.Parse(JsonSerializer.Serialize(result));

        Assert.Equal("Field X is missing.", document.RootElement.GetProperty("detail").GetString());
    }
}
