using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A suggestion to give the user the option to give a quick reply in <see cref="Channel.RCS" />
    /// </summary>
    [PublicAPI]
    public class ReplySuggestion : SuggestionBase
    {
        /// <summary>
        ///     The action of this suggestion
        /// </summary>
        [JsonProperty("action")]
        public override string Action => "reply";
    }
}
