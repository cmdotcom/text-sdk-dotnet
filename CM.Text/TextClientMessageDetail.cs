using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text
{
    /// <summary>
    ///     Data model that contains detailed message information per recipient.
    /// </summary>
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Json interface")]
    public class TextClientMessageDetail
    {
        /// <summary>
        ///     Message details.
        /// </summary>
        /// <value>
        ///     The details.
        /// </value>
        [JsonProperty(Order = 4)]
        public string details { get; set; }

        /// <summary>
        ///     The amount of parts a message is split up to.
        /// </summary>
        /// <value>
        ///     The parts.
        /// </value>
        [JsonProperty(Order = 3)]
        public int parts { get; set; }

        /// <summary>
        ///     The reference to a message.
        /// </summary>
        /// <value>
        ///     The reference.
        /// </value>
        [JsonProperty(Order = 0)]
        public string reference { get; set; }

        /// <summary>
        ///     The status of a message.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonProperty(Order = 1)]
        public string status { get; set; }

        /// <summary>
        ///     The recipient.
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        [JsonProperty(Order = 2)]
        public string to { get; set; }
    }
}
