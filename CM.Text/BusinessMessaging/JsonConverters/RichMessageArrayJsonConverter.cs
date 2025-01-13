using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using CM.Text.BusinessMessaging.Model.MultiChannel;

namespace CM.Text.BusinessMessaging.JsonConverters
{
    /// <summary>
    /// JsonConverter used to deserialize array implementations of IRichMessage when no type information is present in the JSON
    /// </summary>
    public class RichMessageArrayJsonConverter : JsonConverter<IRichMessage[]>
    {
        /// <summary>
        /// Deserializes to a RichMessage array implementation when no type info is present
        /// (param descriptions taken from System.Text.Json.Serialization.JsonConverter)
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="typeToConvert">The type to convert</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The constructed implementation class array</returns>
        /// <exception cref="JsonException">Thrown when no applicable implementation class can be found</exception>
        public override IRichMessage[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Expected start of array");
            }

            var messages = new List<IRichMessage>();
            
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    continue;
                }

                JsonNode node = JsonNode.Parse(ref reader);

                if (node == null)
                    throw new JsonException("Can't deserialize because JSON content is null");

                IRichMessage message;
                if (node["text"] != null)
                {
                    message = JsonSerializer.Deserialize<TextMessage>(node.ToJsonString(), options);
                }
                else if (node["template"] != null)
                {
                    message = JsonSerializer.Deserialize<TemplateMessage>(node.ToJsonString(), options);
                }
                else
                {
                    throw new JsonException("Unsupported message type to deserialize");
                }

                messages.Add(message);
            }

            return messages.ToArray();
        }

        /// <summary>
        /// Serializes a RichMessage array
        /// (param descriptions taken from System.Text.Json.Serialization.JsonConverter)
        /// </summary>
        /// <param name="writer">The writer to write to</param>
        /// <param name="value">The value to convert to JSON</param>
        /// <param name="options">An object that specifies serialization options to use</param>
        public override void Write(Utf8JsonWriter writer, IRichMessage[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var message in value)
            {
                JsonSerializer.Serialize(writer, message, message.GetType(), options);
            }
            writer.WriteEndArray();
        }
    }
}
