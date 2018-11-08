using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text
{
    /// <summary>
    /// Data model that's returned after interaction with CM.com's Text interface.
    /// </summary>
    [PublicAPI]
    public class TextClientResult
    {
        /// <summary>
        /// A message that describes the result.
        /// </summary>
        /// <value>
        /// The status message.
        /// </value>
        [JsonProperty(Order = 0)]
        public string statusMessage { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        [JsonProperty(Order = 1)]
        public TextClientStatusCode statusCode { get; set; }

        /// <summary>
        /// Gets or sets the details for each message.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        [JsonProperty(Order = 2)]
        public IEnumerable<TextClientMessageDetail> details { get; set; }
    }

    /// <summary>
    /// Data model that contains detailed message information per recipient.
    /// </summary>
    [PublicAPI]
    public class TextClientMessageDetail
    {
        /// <summary>
        /// The reference to a message.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        [JsonProperty(Order = 0)]
        public string reference { get; set; }

        /// <summary>
        /// The status of a message.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty(Order = 1)]
        public string status { get; set; }

        /// <summary>
        /// The recipient.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        [JsonProperty(Order = 2)]
        public string to { get; set; }
        
        /// <summary>
        /// The amount of parts a message is split up to.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        [JsonProperty(Order = 3)]
        public int parts { get; set; }

        /// <summary>
        /// Message details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        [JsonProperty(Order = 4)]
        public string details { get; set; }
    }
}
