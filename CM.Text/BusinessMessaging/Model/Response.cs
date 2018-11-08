using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model
{
    internal static class Response
    {
        internal class HttpResponseBody
        {
            [JsonProperty]
            internal string details { get; set; }
            [JsonProperty]
            internal int errorCode { get; set; }
            [JsonProperty]
            internal ResponseMessageDetail[] messages { get; set; }
        }

        internal class ResponseMessageDetail
        {
            [JsonProperty]
            internal string to { get; set; }
            [JsonProperty]
            internal string status { get; set; }
            [JsonProperty]
            internal string reference { get; set; }
            [JsonProperty]
            internal int parts { get; set; }
            [JsonProperty]
            internal string messageDetails { get; set; }
            [JsonProperty]
            internal string messageErrorCode { get; set; }
        }
    }
}
