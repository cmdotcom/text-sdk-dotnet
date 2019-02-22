using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// A suggestion, used in <see cref="Channel.RCS"/>
    /// 
    /// When you want to enable the user can call you, or listen to a recorded spoken message,
    /// this suggestion can be applied. When clicked starts a new call.
    /// </summary>
    [PublicAPI]
    public class DialSuggestion : SuggestionBase {

        /// <summary>
        /// The action of this suggestion
        /// </summary>
        [JsonProperty("action")]
        public override string Action => "Dial";

        /// <summary>
        /// The dial options
        /// </summary>
        [JsonProperty("dial")]
        public Dial Dial { get; set; }
    }
}