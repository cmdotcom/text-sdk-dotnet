using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// WhatsApp interactive messages, see https://developers.facebook.com/docs/whatsapp/guides/interactive-messages for more information
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    [PublicAPI]
    public class WhatsAppInteractiveMessage : IRichMessage
    {

        /// <summary>
        /// Gets or sets the content of the WhatsApp interactive message
        /// </summary>
        [JsonPropertyName("interactive")]
        public WhatsAppInteractiveContent whatsAppInteractiveContent { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive content.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>

    [PublicAPI]
    public class WhatsAppInteractiveContent
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// The Type that will be used,
        /// either list or button
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Your message’s header.
        /// </summary>
        [JsonPropertyName("header")]
        public InteractiveHeader Header { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required Your message’s body.
        /// </summary>
        [JsonPropertyName("body")]
        public InteractiveBody Body { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required Your message’s footer.
        /// </summary>
        [JsonPropertyName("footer")]
        public InteractiveFooter Footer { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        ///Required. Inside action, you must nest:
        ///a button field with your button’s content, and
        ///at least one section object (maximum of 10).
        /// </summary>
        [JsonPropertyName("action")]
        public InteractiveAction Action { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive header.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveHeader
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required.  The header type you would like to use.Supported values are:
        ///text: Used for List Messages and Reply Buttons.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required if type is set to text.
        /// Text for the header.Formatting allows emojis, but not markdown.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Gets or sets the media.
        /// </summary>
        [JsonPropertyName("media")]
        public MediaContent Media { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive body.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveBody
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required  
        /// The body content of the message. Emojis and markdown are supported. Links are supported.
        /// Maximum length: 1024 characters.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive footer.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveFooter
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required if the footer object is present.
        /// The footer content. Emojis and markdown are supported. Links are supported.
        /// Maximum length: 60 characters
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive action.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveAction
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for List Messages.
        /// Button content. It cannot be an empty string and must be unique within the message 
        /// Does not allow emojis or markdown.
        /// </summary>
        [JsonPropertyName("button")]
        public string Button { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for Reply Button Messages.
        /// </summary>
        [JsonPropertyName("buttons")]
        public InteractiveButton[] Buttons { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for List Messages.
        /// </summary>
        [JsonPropertyName("sections")]
        public InteractiveSection[] Sections { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive button.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveButton
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// type: only supported type is reply (for Reply Button Messages).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Button title.It cannot be an empty string and must be unique within the message. 
        /// Does not allow emojis or markdown. Maximum length: 20 characters.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// id: Unique identifier for your button. This ID is returned in the webhook when the button is clicked by the user.
        /// Maximum length: 256 characters.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Reply Message for your button.
        /// </summary>
        [JsonPropertyName("reply")]
        public ReplyMessage Reply { get; set; }
    }

    /// <summary>
    /// WhatsApp reply message.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class ReplyMessage
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// id: Unique identifier for your reply message.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// title: title for your reply button.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive section.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class InteractiveSection
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Title of the section.
        /// Maximum length: 24 characters.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Contains a list of rows.    
        /// </summary>
        [JsonPropertyName("rows")]
        public Rows[] Rows { get; set; }
    }

    /// <summary>
    /// WhatsApp interactive section row.
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    public class Rows
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Title of the row. 
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Id of the row. 
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Description of the row. 
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
