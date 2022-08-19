using JetBrains.Annotations;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("cards")]
        public RichCard[] Cards { get; set; }

        /// <summary>
        ///     The width for the items of the carousel
        /// </summary>
        [JsonPropertyName("cardWidth")]
        public CarouselCardWidth CarouselCardWidth { get; set; }
    }
}
