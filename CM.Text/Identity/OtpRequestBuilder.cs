
using JetBrains.Annotations;

namespace CM.Text.Identity
{
    /// <summary>
    ///     Builder class to construct messages
    /// </summary>
    [PublicAPI]
    public class OtpRequestBuilder
    {
        private readonly OtpRequest _otpRequest;

        /// <summary>
        ///     Creates a new OtpRequestBuilder
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public OtpRequestBuilder(string from, string to)
        {
            _otpRequest = new OtpRequest { From = from, To = to };
        }

        /// <summary>
        ///     Constructs the request.
        /// </summary>
        /// <returns></returns>
        public OtpRequest Build()
        {
            return _otpRequest;
        }

        /// <summary>
        ///     Set the channel
        /// </summary>
        public OtpRequestBuilder WithChannel(string channel)
        {
            _otpRequest.Channel = channel;
            return this;
        }

        /// <summary>
        /// Sets The length of the code (min 4, max 10). default: 5.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public OtpRequestBuilder WithDigits(int digits)
        {
            _otpRequest.Digits = digits;
            return this;
        }

        /// <summary>
        /// The expiry in seconds (min 10, max 3600). default: 60 seconds.
        /// </summary>
        public OtpRequestBuilder WithExpiry(int expiryInSeconds)
        {
            _otpRequest.Expiry = expiryInSeconds;
            return this;
        }

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
        /// <param name="locale"></param>
        /// <returns></returns>
        public OtpRequestBuilder WithLocale(string locale)
        {
            _otpRequest.Locale = locale;
            return this;
        }

        /// <summary>
        /// The app key, when the channel is 'push'
        /// </summary>
        /// <param name="pushAppKey"></param>
        /// <returns></returns>
        public OtpRequestBuilder WithPushAppKey(string pushAppKey)
        {
            _otpRequest.PushAppKey = pushAppKey;
            return this;
        }

        /// <summary>
        /// For WhatsApp, set a custom message. You can use the placeholder {code}, this will be replaced by the actual code.
        /// Example: Your code is: {code}. This is only used as a fallback in case the message could not be delivered via WhatsApp.
        ///
        /// For email, Set a custom message to be used in the email message. Do not include the {code} placeholder.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public OtpRequestBuilder WithMessage(string message)
        {
            _otpRequest.Message = message;
            return this;
        }
    }
}
