using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Opens the navigation app of the user with a pin at the specified location in <see cref="Channel.RCS" />.
    /// </summary>
    [PublicAPI]
    public class ViewLocationSuggestion : SuggestionBase
    {
        /// <summary>
        ///     The action of this suggestion
        /// </summary>
        [JsonPropertyName("action")]
        public override string Action => "viewLocation";

        /// <summary>
        ///     The location options
        /// </summary>
        [JsonPropertyName("viewLocation")]
        public ViewLocationOptions Location { get; set; }
    }
}
