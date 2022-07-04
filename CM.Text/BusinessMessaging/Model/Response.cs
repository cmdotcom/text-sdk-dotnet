using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Json interface")]
    internal static class Response
    {
        internal class HttpResponseBody
        {
            [JsonInclude]
            internal string details { get; set; }

            [JsonInclude]
            internal int errorCode { get; set; }

            [JsonInclude]
            internal ResponseMessageDetail[] messages { get; set; }
        }

        internal class ResponseMessageDetail
        {
            [JsonInclude]
            internal string messageDetails { get; set; }

            [JsonInclude]
            internal string messageErrorCode { get; set; }

            [JsonInclude]
            internal int parts { get; set; }

            [JsonInclude]
            internal string reference { get; set; }

            [JsonInclude]
            internal string status { get; set; }

            [JsonInclude]
            internal string to { get; set; }
        }
    }
}
