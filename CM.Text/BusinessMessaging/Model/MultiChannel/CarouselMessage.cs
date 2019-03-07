using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// A message containing a carousel of richCards.
    /// Currently only supported by <see cref="Channel.RCS"/>/
    /// </summary>
    [PublicAPI]
    public class CarouselMessage : IRichMessage {
        /// <summary>
        /// Contains the rich cards
        /// </summary>
        [JsonProperty("carousel")]
        public Carousel Carousel { get; set; }
    }
}
