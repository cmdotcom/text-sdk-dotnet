using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A suggestion to give the user the option to give a quick reply in <see cref="Channel.RCS" />
    /// </summary>
    [PublicAPI]
    public class ReplySuggestion : SuggestionBase
    {
        /// <summary>
        ///     Description of the Reply suggestion
        /// </summary>
        /// <remarks>
        ///     For <see cref="Channel.Twitter" />
        /// </remarks>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     The thumbnail image of the Reply suggestion
        /// </summary>
        /// <remarks>
        ///     For <see cref="Channel.FacebookMessenger" />
        /// </remarks>
        [JsonPropertyName("media")]
        public MediaContent Media { get; set; }
    }
}
