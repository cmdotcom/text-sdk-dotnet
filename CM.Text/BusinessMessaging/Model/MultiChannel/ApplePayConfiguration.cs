
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Object that describes the Apple Pay configuration
    /// </summary>
    public class ApplePayConfiguration 
    {
        /// <summary>
        /// (Required) A unique identifier that represents a merchant for Apple Pay.
        /// </summary>
        [JsonPropertyName("merchantName")]
        public string MerchantName { get; set; }
        /// <summary>
        /// (Required) Description of the item being bought.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// (Required) A unique identifier that represents a order
        /// </summary>
        [JsonPropertyName("orderReference")]
        public string OrderReference { get; set; }

        /// <summary>
        /// An array of line items explaining payments and additional charges. 
        /// </summary>
        /// <remarks> Line items are not required. However, the array cannot be empty if the lineItems key is present. 
        /// </remarks>
        [JsonPropertyName("lineItems")]
        public LineItem[] LineItems { get; set; }

        /// <summary>
        ///  A dictionary containing the total. 
        /// </summary>
        /// <remarks> The total amount must be greater than zero to pass validation. 
        /// </remarks>
        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Email address of the Apple Pay contact.
        /// </summary>
        [JsonPropertyName("recipientEmail")]
        public string RecipientEmail { get; set; }
        /// <summary>
        /// Value indicating the currency code of the apple pay request
        /// </summary>
        /// <remarks> Value must be in upper case.
        /// </remarks>
        [JsonPropertyName("currencyCode")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Country of the Apple Pay contact.
        /// </summary>
        /// <remarks> Value must be in upper case.
        /// </remarks>
        [JsonPropertyName("recipientCountryCode")]
        public string RecipientCountryCode { get; set; }
        /// <summary>
        /// The Language of the Country of the Apple Pay Contact
        /// </summary>
        /// <remarks> Value must be in lower case.
        /// </remarks>
        [JsonPropertyName("languageCountryCode")]
        public string languageCountryCode { get; set; }
        /// <summary>
        /// Value indicating that a billing address is required
        /// </summary>
        [JsonPropertyName("billingAddressRequired")]
        public bool BillingAddressRequired { get; set; }
        /// <summary>
        ///  Value indicating that a shipping contact is required
        /// </summary>
        [JsonPropertyName("shippingContactRequired")]
        public bool ShippingContactRequired { get; set; }
    }
}
