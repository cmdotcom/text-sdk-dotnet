using System;
using System.Linq;
using CM.Text.BusinessMessaging.Model;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using CM.Text.Common;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging
{
    /// <summary>
    ///     Builder class to construct messages
    /// </summary>
    [PublicAPI]
    public class MessageBuilder
    {
        private readonly Message _message;
        private RichContent _richContent;

        /// <summary>
        ///     Creates a new MessageBuilder
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MessageBuilder(string messageText, string from, params string[] to)
        {
            this._message = new Message
            {
                Body = new Body
                {
                    Content = messageText, Type = BusinessMessagingApi.Constant.BusinessMessagingBodyTypeAuto
                },
                Recipients = to.Select(toEntry => new Recipient {Number = toEntry})
                    .ToArray(),
                From = from,
                CustomGrouping3 = Constant.TextSdkReference
            };
        }

        /// <summary>
        ///     Constructs the message.
        /// </summary>
        /// <returns></returns>
        public Message Build()
        {
            this._message.RichContent = this._richContent;
            return this._message;
        }

        /// <summary>
        ///     Adds the allowed channels field, which forces a message to only use certain routes.
        ///     You can define a list of which channels you want your message to use.
        ///     Not defining any channels will be interpreted as allowing all channels.
        /// </summary>
        /// <remarks>
        ///     Note that for channels other than SMS, CM needs to configure the out going flows.
        ///     For those flows to work, we need to be contacted.
        /// </remarks>
        public MessageBuilder WithAllowedChannels(params Channel[] channels)
        {
            this._message.AllowedChannels = channels;
            return this;
        }

        /// <summary>
        ///     Add a reference to the message.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MessageBuilder WithReference(string reference)
        {
            this._message.Reference = reference;
            return this;
        }

        /// <summary>
        ///     Adds a message that replaces the <see cref="Message.Body" /> for channels that support
        ///     rich content (all channels except <see cref="Channel.SMS" />, <see cref="Channel.Voice" />
        ///     and <see cref="Channel.Push" /> at this moment)
        /// </summary>
        /// <param name="richMessage"></param>
        /// <returns></returns>
        public MessageBuilder WithRichMessage(IRichMessage richMessage)
        {
            if (this._richContent == null)
                this._richContent = new RichContent();

            this._richContent.AddConversationPart(richMessage);
            return this;
        }

        /// <summary>
        ///     Adds suggestions to the message. It is dependent on the channel that is used which
        ///     suggestions are supported.
        /// </summary>
        /// <param name="suggestions"></param>
        /// <returns></returns>
        public MessageBuilder WithSuggestions(params SuggestionBase[] suggestions)
        {
            if (this._richContent == null)
                this._richContent = new RichContent();

            this._richContent.Suggestions = suggestions;
            return this;
        }

        /// <summary>
        ///     Used for Hybrid messaging, see https://docs.cmtelecom.com/en/hybrid-messaging/v2.0.0 for more information
        ///     Messages will be sent over the <see cref="Channel.Push" /> channel.
        /// </summary>
        public MessageBuilder WitHybridAppKey(Guid appKey)
        {
            this._message.HybridAppKey = appKey;
            return this;
        }
    }
}
