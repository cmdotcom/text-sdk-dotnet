using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
{
    public class Request
    {
        public class MessagesEnvelope
        {
            [JsonPropertyName("authentication")]
            [JsonInclude]
            public Authentication Authentication { get; set; }

            [JsonPropertyName("msg")]
            public Message[] Messages { get; set; }
        }

        public class Authentication
        {
            [JsonPropertyName("producttoken")]
            public string ProductToken { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        }
    }
}
