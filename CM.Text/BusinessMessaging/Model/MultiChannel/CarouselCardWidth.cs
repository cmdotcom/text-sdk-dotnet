using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// Used by a <see cref="Carousel"/> to set the width
    /// </summary>
    [PublicAPI]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CarouselCardWidth {
        /// <summary>
        /// Small cards
        /// </summary>
        Small,
        /// <summary>
        /// Medium sized cards
        /// </summary>
        Medium
    }
}