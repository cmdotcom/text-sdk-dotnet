using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Contains information for a <see cref="DialSuggestion" />
    /// </summary>
    [PublicAPI]
    public class Dial
    {
        /// <summary>
        ///     The number to call (in international format)
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
