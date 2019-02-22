using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model {
    /// <summary>
    /// A destination mobile number.
    /// </summary>
    [PublicAPI]
    public class Recipient {
        /// <summary>
        /// This value should be in international format.
        /// A single mobile number per request. Example: '00447911123456'
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
