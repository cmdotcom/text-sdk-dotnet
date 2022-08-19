using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Json interface")]
    internal static class Response
    {
        internal class HttpResponseBody
        {
            [JsonPropertyName("details")]
            internal string details { get; set; }

            [JsonPropertyName("errorCode")]
            internal int errorCode { get; set; }

            [JsonPropertyName("messages")]
            internal ResponseMessageDetail[] messages { get; set; }
        }

        internal class ResponseMessageDetail
        {
            [JsonPropertyName("messageDetails")]
            internal string messageDetails { get; set; }

            [JsonPropertyName("messageErrorCode")]
            internal string messageErrorCode { get; set; }

            [JsonPropertyName("parts")]
            internal int parts { get; set; }

            [JsonPropertyName("reference")]
            internal string reference { get; set; }

            [JsonPropertyName("status")]
            internal string status { get; set; }

            [JsonPropertyName("to")]
            internal string to { get; set; }
        }
    }
}
