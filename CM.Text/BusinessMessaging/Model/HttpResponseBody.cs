using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
{

    /// <summary>
    /// CM Messaging API response body containing API related info
    /// </summary>
    public class HttpResponseBody
    {
        /// <summary>
        /// API Request details
        /// </summary>
        [JsonInclude]
        public string details { get; private set; }

        /// <summary>
        /// JSON POST Error codes. Full description of each code available in the development documentation
        /// </summary>
        [JsonInclude]
        public int errorCode { get; private set; }

        /// <summary>
        /// Each message that was sent in the original request
        /// </summary>
        [JsonInclude]
        public ResponseMessageDetail[] messages { get; private set; }
    }
}
