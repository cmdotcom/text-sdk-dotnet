using Newtonsoft.Json;

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
        [JsonProperty("merchantName")]
        public string MerchantName { get; set; }
        /// <summary>
        /// (Required) Description of the item being bought.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// (Required) A unique identifier that represents a order
        /// </summary>
        [JsonProperty("orderReference")]
        public string OrderReference { get; set; }

        /// <summary>
        /// An array of line items explaining payments and additional charges. 
        /// </summary>
        /// <remarks> Line items are not required. However, the array cannot be empty if the lineItems key is present. 
        /// </remarks>
        [JsonProperty("lineItems")]
        public LineItem[] LineItems { get; set; }

        /// <summary>
        ///  A dictionary containing the total. 
        /// </summary>
        /// <remarks> The total amount must be greater than zero to pass validation. 
        /// </remarks>
        [JsonProperty("total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Email address of the Apple Pay contact.
        /// </summary>
        [JsonProperty("recipientEmail")]
        public string RecipientEmail { get; set; }
        /// <summary>
        /// Value indicating the currency code of the apple pay request
        /// </summary>
        /// <remarks> Value must be in upper case.
        /// </remarks>
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Country of the Apple Pay contact.
        /// </summary>
        /// <remarks> Value must be in upper case.
        /// </remarks>
        [JsonProperty("recipientCountryCode")]
        public string RecipientCountryCode { get; set; }
        /// <summary>
        /// The Language of the Country of the Apple Pay Contact
        /// </summary>
        /// <remarks> Value must be in lower case.
        /// </remarks>
        [JsonProperty("languageCountryCode")]
        public string languageCountryCode { get; set; }
        /// <summary>
        /// Value indicating that a billing address is required
        /// </summary>
        [JsonProperty("billingAddressRequired")]
        public bool BillingAddressRequired { get; set; }
        /// <summary>
        ///  Value indicating that a shipping contact is required
        /// </summary>
        [JsonProperty("shippingContactRequired")]
        public bool ShippingContactRequired { get; set; }
    }
}
