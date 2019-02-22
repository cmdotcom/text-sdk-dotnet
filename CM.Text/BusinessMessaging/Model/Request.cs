using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model
{
    internal static class Request
    {
        internal class MessagesEnvelope
        {
            [JsonProperty("authentication")]
            internal Authentication Authentication { get; set; }
            [JsonProperty("msg")]
            internal Message[] Messages { get; set; }
        }

        internal class Authentication
        {
            [JsonProperty("producttoken")]
            internal string ProductToken { get; set; }
        }
    }
}
