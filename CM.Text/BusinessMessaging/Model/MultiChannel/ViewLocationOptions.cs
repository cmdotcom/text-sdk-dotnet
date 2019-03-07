using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// The options for a <see cref="ViewLocationSuggestion"/> in <see cref="Channel.RCS"/>.
    /// </summary>
    [PublicAPI]
    public class ViewLocationOptions {
        /// <summary>
        /// The latitude in degrees
        /// </summary>
        /// <example>51.603802</example>
        /// <remarks>For some connections either a combination of Latitude and <see cref="Longitude"/> or <see cref="SearchQuery"/> is required,
        /// for other connections both may be required.
        /// </remarks>
        [JsonProperty("latitude")]
        public string Latitude { get; set; }
        /// <summary>
        /// The longitude in degrees
        /// </summary>
        /// <example>4.770821</example>
        /// <remarks>For some connections either a combination of <see cref="Latitude"/> and Longitude or <see cref="SearchQuery"/> is required,
        /// for other connections both may be required.
        /// </remarks>
        [JsonProperty("longitude")]
        public string Longitude { get; set; }
        /// <summary>
        /// The label to display at the pin in a map.
        /// </summary>
        /// <remarks>May be optional for some channels, required for others</remarks>
        [JsonProperty("label")]
        public string Label { get; set; }
        /// <summary>
        /// Search for this location instead of using the latitude/longitude.
        /// </summary>
        /// <remarks>For some connections either a combination of <see cref="Latitude"/> and <see cref="Latitude"/> or SearchQuery is required,
        /// for other connections both may be required.
        /// </remarks>
        [JsonProperty("searchQuery")]
        public string SearchQuery { get; set; }

        /// <summary>
        /// Can be used in some <see cref="Channel.RCS"/> connections to display a radius instead of only a pointer
        /// </summary>
        [JsonProperty("radius")]
        public int? Radius { get; set; }
    }
}
