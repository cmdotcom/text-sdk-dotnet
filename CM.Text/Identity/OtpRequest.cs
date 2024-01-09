using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.Identity
{
    /// <summary>
    /// A request to send an OTP towards an end-user.
    /// </summary>
    [PublicAPI]
    public class OtpRequest
    {
        /// <summary>
        ///     Required: This is the sender name.
        ///     The maximum length is 11 alphanumerical characters or 16 digits. Example: 'MyCompany'
        /// </summary>
        [JsonPropertyName("from")]
        public string From { get; set; }
        
        /// <summary>
        ///     Required: The destination mobile numbers.
        ///     This value should be in international format.
        ///     A single mobile number per request. Example: '00447911123456'
        /// </summary>
        [JsonPropertyName("to")]
        public string To { get; set; }
        
        /// <summary>
        /// The length of the code (min 4, max 10). default: 5.
        /// </summary>
        [JsonPropertyName("digits")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Digits { get; set; }
        
        /// <summary>
        /// The expiry in seconds (min 10, max 3600). default: 60 seconds.
        /// </summary>
        [JsonPropertyName("expiry")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Expiry { get; set; }

        /// <summary>
        /// The channel to send the code.
        /// Supported values: auto, sms, push, whatsapp, voice, email.
        /// Channel auto is only available with a SOLiD subscription.
        /// </summary>
        [JsonPropertyName("channel")] 
        public string Channel { get; set; } = "sms";

        /// <summary>
        /// The locale, for WhatsApp supported values: en, nl, fr, de, it, es.
        /// Default: en
        /// 
        /// For Voice: the spoken language in the voice call,
        /// supported values: de-DE, en-AU, en-GB, en-IN, en-US, es-ES, fr-CA, fr-FR, it-IT, ja-JP, nl-NL
        /// Default: en-GB.
        /// 
        /// For Email: The locale for the email template.
        /// </summary>
        [JsonPropertyName("locale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        [CanBeNull]
        public string Locale { get; set; }
        
        /// <summary>
        /// The app key, when <see cref="Channel"/> is 'push'
        /// </summary>
        [JsonPropertyName("pushAppKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        [CanBeNull]
        public string PushAppKey { get; set; } 
        
        /// <summary>
        /// For WhatsApp, set a custom message. You can use the placeholder {code}, this will be replaced by the actual code.
        /// Example: Your code is: {code}. This is only used as a fallback in case the message could not be delivered via WhatsApp.
        ///
        /// For email, Set a custom message to be used in the email message. Do not include the {code} placeholder.
        /// </summary>
        [JsonPropertyName("message")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] 
        [CanBeNull]
        public string Message { get; set; }
    }
}
