using System.Collections.Generic;
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
        public MessageBuilder(string messageText, string from, IEnumerable<string> to) {
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
        /// Constructs the message.
        /// </summary>
        /// <returns></returns>
        public Message Build() {
            return message;
        }
    }
}
