using System.Text.Json;
using System.Text.Json.Serialization;
using ResultHandler.Core.Enums;
using ResultHandler.Mapping;

namespace ResultHandler.Serialization;

public sealed class ResultStatusJsonConverter : JsonConverter<ResultStatus>
{
    public override ResultStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var numericValue))
        {
            return numericValue.ToResultStatus();
        }

        if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out var parsedValue))
        {
            return parsedValue.ToResultStatus();
        }

        throw new JsonException($"Unable to convert JSON value to {nameof(ResultStatus)}: expected a numeric HTTP status code.");
    }

    public override void Write(Utf8JsonWriter writer, ResultStatus value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue((int)value.ToHttpStatusCode());
    }
}
