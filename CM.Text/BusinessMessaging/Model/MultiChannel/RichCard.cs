using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// A rich card, which can be used to display media, text and images in <see cref="Channel.RCS"/>.
    /// </summary>
    [PublicAPI]
    public class RichCard : TextMessage {
        /// <summary>
        /// The image or video of the card.
        /// </summary>
        [JsonProperty("media")]
        public MediaContent Media { get; set; }

        /// <summary>
        /// Optional: the header for a rich card
        /// </summary>
        [JsonProperty("header")]
        public string Header { get; set; }

        /// <summary>
        /// Suggestions, used in channels that support these, such as <see cref="Channel.RCS"/>.
        /// </summary>
        [JsonProperty("suggestions")]
        public SuggestionBase[] Suggestions { get; set; }
    }
}
