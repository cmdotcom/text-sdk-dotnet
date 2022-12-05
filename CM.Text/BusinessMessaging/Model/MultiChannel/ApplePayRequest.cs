using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     ApplePay request rich message
    /// </summary>
    public class ApplePayRequest : IRichMessage
    {
        /// <summary>
        /// Gets or sets the apple pay configuration.
        /// </summary>
        [JsonPropertyName("payment")]
        public ApplePayConfiguration ApplePayConfiguration { get; set; }
    }
}
