using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A carousel contains two or more <see cref="RichCard" />s
    /// </summary>
    [PublicAPI]
    public class Carousel
    {
        /// <summary>
        ///     The cards of the carousel
        /// </summary>
        [JsonProperty("cards")]
        public RichCard[] Cards { get; set; }

        /// <summary>
        ///     The width for the items of the carousel
        /// </summary>
        [JsonProperty("cardWidth")]
        public CarouselCardWidth CarouselCardWidth { get; set; }
    }
}
