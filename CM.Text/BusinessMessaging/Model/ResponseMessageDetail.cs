using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model
{
    /// <summary>
    /// CM Messaging API response containing message related info
    /// </summary>
    public class ResponseMessageDetail
    {
        /// <summary>
        /// Description of this message
        /// </summary>
        [JsonInclude]
        public string messageDetails { get; private set; }

        /// <summary>
        /// Error code specific to this message.
        /// </summary>
        [JsonInclude]
        public int messageErrorCode { get; private set; }

        /// <summary>
        /// How many parts this message was split in
        /// </summary>
        [JsonInclude]
        public int parts { get; private set; }

        /// <summary>
        /// The external reference sent to identify this message
        /// </summary>
        [JsonInclude]
        public string reference { get; private set; }

        /// <summary>
        /// Status of the message
        /// </summary>
        [JsonInclude]
        public string status { get; private set; }

        /// <summary>
        /// Recipient of this message
        /// </summary>
        [JsonInclude]
        public string to { get; private set; }
    }
}
