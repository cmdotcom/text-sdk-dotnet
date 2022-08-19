using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text
{
    /// <summary>
    ///     Data model that's returned after interaction with CM.com's Text interface.
    /// </summary>
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Json interface")]
    public class TextClientResult
    {
        /// <summary>
        ///     Gets or sets the details for each message.
        /// </summary>
        /// <value>
        ///     The details.
        /// </value>
        [JsonPropertyOrder(2)]
        public IEnumerable<TextClientMessageDetail> details { get; set; }

        /// <summary>
        ///     Gets or sets the status code.
        /// </summary>
        /// <value>
        ///     The status code.
        /// </value>
        [JsonPropertyOrder(1)]
        public TextClientStatusCode statusCode { get; set; }

        /// <summary>
        ///     A message that describes the result.
        /// </summary>
        /// <value>
        ///     The status message.
        /// </value>
        [JsonPropertyOrder(0)]
        public string statusMessage { get; set; }
    }
}
