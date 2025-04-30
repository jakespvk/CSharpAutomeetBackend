using System.Text.Json;
using System.Text.Json.Serialization;
using AutomeetBackend.Models;

namespace AutomeetBackend
{
    public class DbAdapterConverter : JsonConverter<DbAdapter>
    {
        public override DbAdapter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using JsonDocument jsonDoc = JsonDocument.ParseValue(ref reader);
            JsonElement root = jsonDoc.RootElement;

            if (!root.TryGetProperty("type", out var typeProperty))
            {
                throw new JsonException("Must provide a 'type' param");
            }

            var type = typeProperty.GetString()?.ToLowerInvariant();

            return type switch
            {
                "attio" => JsonSerializer.Deserialize<AttioAdapter>(root.GetRawText(), options)
                    ?? throw new JsonException("Failed to deserialize AttioAdapter"),
                "activecampaign" => JsonSerializer.Deserialize<ActiveCampaignAdapter>(root.GetRawText(), options)
                    ?? throw new JsonException("Failed to deserialize ActiveCampaignAdapter"),
                _ => throw new JsonException($"DbAdapter type '{type}' is not supported")
            };
        }

        public override void Write(Utf8JsonWriter writer, DbAdapter value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
        }
    }
}
