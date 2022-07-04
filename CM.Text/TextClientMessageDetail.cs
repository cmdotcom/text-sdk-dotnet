using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

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
        [JsonPropertyOrder(4)]
        public string details { get; set; }

        /// <summary>
        ///     The amount of parts a message is split up to.
        /// </summary>
        /// <value>
        ///     The parts.
        /// </value>
        [JsonPropertyOrder(3)]
        public int parts { get; set; }

        /// <summary>
        ///     The reference to a message.
        /// </summary>
        /// <value>
        ///     The reference.
        /// </value>
        [JsonPropertyOrder(0)]
        public string reference { get; set; }

        /// <summary>
        ///     The status of a message.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        [JsonPropertyOrder(1)]
        public string status { get; set; }

        /// <summary>
        ///     The recipient.
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        [JsonPropertyOrder(2)]
        public string to { get; set; }
    }
}
