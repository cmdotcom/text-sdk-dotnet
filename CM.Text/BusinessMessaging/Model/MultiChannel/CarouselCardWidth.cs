using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Used by a <see cref="Carousel" /> to set the width
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CarouselCardWidth
    {
        /// <summary>
        ///     Small cards
        /// </summary>
        Small,

        /// <summary>
        ///     Medium sized cards
        /// </summary>
        Medium
    }
}
