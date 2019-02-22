using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// Opens the navigation app of the user with a pin at the specified location in <see cref="Channel.RCS"/>.
    /// </summary>
    [PublicAPI]
    public class ViewLocationSuggestion : SuggestionBase {
        /// <summary>
        /// The action of this suggestion
        /// </summary>
        [JsonProperty("action")]
        public override string Action => "viewLocation";

        /// <summary>
        /// The location options
        /// </summary>
        [JsonProperty("viewLocation")]
        public ViewLocationOptions Location { get; set; }
    }
}