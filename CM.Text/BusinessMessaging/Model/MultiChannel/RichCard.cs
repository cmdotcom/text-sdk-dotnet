using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A rich card, which can be used for <see cref="Channel.RCS" />.
    /// </summary>
    [PublicAPI]
    public class RichCard : TextMessage
    {
        /// <summary>
        ///     Optional: the header for a rich card
        /// </summary>
        [JsonPropertyName("header")]
        public string Header { get; set; }

        /// <summary>
        ///     The image or video of the card.
        /// </summary>
        [JsonPropertyName("media")]
        public MediaContent Media { get; set; }
    }
}
