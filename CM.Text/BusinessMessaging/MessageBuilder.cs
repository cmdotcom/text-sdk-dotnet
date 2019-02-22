using System;
using System.Linq;
using CM.Text.BusinessMessaging.Model;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging {
    /// <summary>
    /// Builder class to construct messages
    /// </summary>
    [PublicAPI]
    public class MessageBuilder {
        
        private readonly Message message;
        
        /// <summary>
        /// Creates a new MessageBuilder
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MessageBuilder(string messageText, string from, params string[] to) {
            message = new Message();
            message.Body = new Body {
                Content = messageText,
                Type = BusinessMessagingApi.Constant.BusinessMessagingBodyTypeAuto
            };
            message.Recipients = to.Select(toEntry => new Recipient {Number = toEntry}).ToArray();
            message.From = from;
            message.CustomGrouping3 = Common.Constant.TextSdkReference;
        }

        /// <summary>
        /// Add a reference to the message.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MessageBuilder WithReference(string reference) {
            message.Reference = reference;
            return this;
        }

        /// <summary>
        /// Adds the allowed channels field, which forces a message to only use certain routes.
        /// You can define a list of which channels you want your message to use.
        /// Not defining any channels will be interpreted as allowing all channels.
        /// </summary>
        /// <remarks>Note that for channels other than SMS, CM needs to configure the out going flows.
        /// For those flows to work, we need to be contacted.</remarks>
        public MessageBuilder WithAllowedChannels(params Channel[] channels) {
            message.AllowedChannels = channels;
            return this;
        }

        /// <summary>
        /// Used for Hybrid messaging, see https://docs.cmtelecom.com/en/hybrid-messaging/v2.0.0 for more information
        /// Messages will be sent over the <see cref="Channel.Push"/> channel.
        /// </summary>
        public MessageBuilder WitHybridAppKey(Guid appKey) {
            message.HybridAppKey = appKey;
            return this;
        }

        /// <summary>
        /// Constructs the message.
        /// </summary>
        /// <returns></returns>
        public Message Build() {
            return message;
        }
    }
}
