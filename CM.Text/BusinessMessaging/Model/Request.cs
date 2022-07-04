using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
{
    internal static class Request
    {
        internal class MessagesEnvelope
        {
            [JsonPropertyName("authentication")]
            internal Authentication Authentication { get; set; }

            [JsonPropertyName("msg")]
            internal Message[] Messages { get; set; }
        }

        internal class Authentication
        {
            [JsonPropertyName("producttoken")]
            internal string ProductToken { get; set; }
        }
    }
}
