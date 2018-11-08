using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model
{
    internal static class Request
    {
        internal class HttpPostBody
        {
            [JsonProperty]
            internal Messages messages { get; set; }
        }

        internal class Messages
        {
            [JsonProperty]
            internal Authentication authentication { get; set; }
            [JsonProperty]
            internal Message[] msg { get; set; }
        }

        internal class Authentication
        {
            [JsonProperty]
            internal string producttoken { get; set; }
        }

        internal class Message
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            internal string reference { get; set; }
            [JsonProperty]
            internal string from { get; set; }
            [JsonProperty]
            internal To[] to { get; set; }
            [JsonProperty]
            internal Body body { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            internal string customGrouping { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            internal string customGrouping2 { get; set; }
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            internal string customGrouping3 { get; set; }
        }

        internal class To
        {
            [JsonProperty]
            internal string number { get; set; }
        }

        internal class Body
        {
            [JsonProperty]
            internal string content { get; set; }
            [JsonProperty]
            internal string type { get; set; }
        }
    }
}
