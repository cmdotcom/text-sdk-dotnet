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
            _message = new Message
            {
                Body = new Body
                {
                    Content = messageText,
                    Type = Constant.BusinessMessagingBodyTypeAuto
                },
                Recipients = to.Select(toEntry => new Recipient { Number = toEntry })
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
            _message.RichContent = _richContent;
            return _message;
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
            _message.AllowedChannels = channels;
            return this;
        }

        /// <summary>
        ///     Add a reference to the message.
        /// </summary>
        /// <param name="reference"></param>
        /// <returns></returns>
        public MessageBuilder WithReference(string reference)
        {
            _message.Reference = reference;
            return this;
        }

        /// <summary>
        ///     Add a validity period to the message.
        /// </summary>
        /// <remarks>
        ///     You can supply the time zone for the validity period using either of the following formats:
        ///     
        ///     Absolute date and time:
        ///     
        ///     2017-04-20 11:50:05 GMT
        ///     2017-04-20 11:50:05+8
        ///     2017-04-20 11:55:05-07:00
        ///     If no time zone was specified, CE(S)T will be used. (CM local time)
        ///     
        ///     Relative offset in hour(h) or minute(m)
        ///     
        ///     2h
        ///     30m
        ///     You can set the validity in either hours or minutes. A combination of both is not supported.
        /// </remarks>
        /// <param name="period"></param>
        /// <returns></returns>
        public MessageBuilder WithValidityPeriod(string period)
        {
            _message.Validity = period;
            return this;
        }

        /// <summary>
        ///     Adds a message that replaces the <see cref="Message.Body" /> for channels that support
        ///     rich content (all channels except <see cref="Channel.SMS" />, <see cref="Channel.Voice" />
        ///     and <see cref="Channel.Push" /> at this moment)
        /// </summary>
        /// <param name="richMessage"></param>
        /// <returns></returns>
        public MessageBuilder WithRichMessage(RichMessage richMessage)
        {
            if (_richContent == null)
                _richContent = new RichContent();

            _richContent.AddConversationPart(richMessage);
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
            if (_richContent == null)
                _richContent = new RichContent();

            _richContent.Suggestions = suggestions;
            return this;
        }

        /// <summary>
        ///     Used for Hybrid messaging, see https://developers.cm.com/messaging/docs for more information
        ///     Messages will be sent over the <see cref="Channel.Push" /> channel.
        /// </summary>
        public MessageBuilder WitHybridAppKey(Guid appKey)
        {
            _message.HybridAppKey = appKey;
            return this;
        }

        /// <summary>
        ///  Adds a WhatsApp template message that replaces the <see cref="Message.Body" /> for WhatsApp
        ///  please note that you need to have approved wa templates.
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public MessageBuilder WithTemplate(TemplateMessage template)
        {
            if (_richContent == null)
                _richContent = new RichContent();

            _richContent.AddConversationPart(template);
            return this;
        }

        /// <summary>
        ///  Adds a WhatsApp interactive message that replaces the <see cref="Message.Body" /> for WhatsApp
        /// </summary>
        /// <param name="interactive"></param>
        /// <returns></returns>
        public MessageBuilder WithInteractive(WhatsAppInteractiveMessage interactive)
        {
            if (_richContent == null)
                _richContent = new RichContent();

            _richContent.AddConversationPart(interactive);
            return this;
        }

        /// <summary>
        ///  Adds a ApplePay request .
        /// </summary>
        /// <param name="applePayRequest"></param>
        /// <returns></returns>
        public MessageBuilder WithApplePay(ApplePayRequest applePayRequest)
        {
            if (_richContent == null)
                _richContent = new RichContent();

            _richContent.AddConversationPart(applePayRequest);
            return this;
        }
    }
}
