using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Contextual properties of the message. Currently only applicable to <see cref="Channel.WhatsApp" />
    /// Docs: https://docs.cm.com/messaging/whatsapp/whatsapp-inbound#replying-to-a-users-message
    /// </summary>
    public class MessageContext
    {
        /// <summary>
        /// Message ID to which the current message is a reply
        /// </summary>
        [JsonPropertyName("message_id")]
        [CanBeNull]
        public string MessageId { get; set; }
    }
}
