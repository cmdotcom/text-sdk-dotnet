
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// A set of line items that explain recurring payments and additional charges and discounts.
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// (Required) A short, localized description of the line item.
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }
        /// <summary>
        /// A value that indicates whether the line item is final or pending.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// (Required) The monetary amount of the line item.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
