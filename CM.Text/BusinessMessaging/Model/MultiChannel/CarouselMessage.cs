using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A message containing multiple carousels.
    ///     Currently only supported by <see cref="Channel.RCS" />/
    /// </summary>
    [PublicAPI]
    public class CarouselMessage : IRichMessage
    {
        /// <summary>
        ///     Contains the rich cards
        /// </summary>
        [JsonPropertyName("carousel")]
        public Carousel Carousel { get; set; }
    }
}
