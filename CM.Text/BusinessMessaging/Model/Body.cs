using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model {
    /// <summary>
    /// Represents the Body element of the message.
    /// </summary>
    [PublicAPI]
    public class Body {
        /// <summary>
        /// The actual text body of the message.
        /// 
        /// By default the CM gateway interprets messages as if sent with the standard 7 bit GSM encoding.
        /// If you want to send messages using e.g. Arabic, Cyrillic of Greek characters
        /// you will need to use the unicode UCS2 encoding.
        ///
        /// Set the <see cref="Type"/> to Auto to let the gateway do the encoding detection.
        /// 
        /// Please note that there are a few limitations to using unicode encoded messages:
        /// 
        /// Unicode messages can contain up to 70 characters. In the case of multipart messages, this becomes 66 characters per part.
        /// You will need to POST the XML or JSON file. A HTTP GET request cannot handle the Unicode characters
        /// Another note is that not all operators in the world are able to handle Unicode messages, so you will need to test for which operators it works.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        /// <summary>
        /// When the type is set to 'auto' then the gateway will do the encoding detection.
        /// In case it detects characters that are not part of the GSM character set,
        /// the message will be delivered as Unicode.
        /// If the message contains more than 70 characters in Unicode format it will be split into a
        /// multipart message.
        /// You can limit the number of parts by setting the maximum number of message parts.
        /// <see cref="Message.MaximumNumberOfMessageParts"/> 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
