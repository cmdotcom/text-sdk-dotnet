using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Whatsapp interactive messages, see https://developers.facebook.com/docs/whatsapp/guides/interactive-messages for more information
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>

    [PublicAPI]
    public class WhatsAppInteractiveMessage : IRichMessage
    {
      
        [JsonProperty("interactive")]
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
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Your message’s header.
        /// </summary>
        [JsonProperty("header")]
        public InteractiveHeader Header { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required Your message’s body.
        /// </summary>
        [JsonProperty("body")]
        public InteractiveBody Body { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required Your message’s footer.
        /// </summary>
        [JsonProperty("footer")]
        public InteractiveFooter Footer { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        ///Required. Inside action, you must nest:
        ///a button field with your button’s content, and
        ///at least one section object (maximum of 10).
        /// </summary>
        [JsonProperty("action")]
        public InteractiveAction Action { get; set; }
    }
    public class InteractiveHeader
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required.  The header type you would like to use.Supported values are:
        ///text: Used for List Messages and Reply Buttons.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required if type is set to text.
        /// Text for the header.Formatting allows emojis, but not markdown.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class InteractiveBody
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required  
        /// The body content of the message.Emojis and markdown are supported. Links are supported.
        /// Maximum length: 1024 characters.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class InteractiveFooter
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required if the footer object is present.
        /// The footer content.Emojis and markdown are supported.Links are supported.
        /// Maximum length: 60 characters
        /// </summary>
       [JsonProperty("text")]
        public string Text { get; set; }
    }
    public class InteractiveAction
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for List Messages.
        /// Button content.It cannot be an empty string and must be unique within the message 
        /// Does not allow emojis or markdown.
         [JsonProperty("button")]
        public string Button { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for Reply Button Messages.
        [JsonProperty("buttons")]
        public InteractiveButton[] Buttons { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Required for List Messages.
        [JsonProperty("sections")]
        public InteractiveSection[] Sections { get; set; }
    }
    public class InteractiveButton
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// type: only supported type is reply (for Reply Button Messages).
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Button title.It cannot be an empty string and must be unique within the message. 
        /// Does not allow emojis or markdown. Maximum length: 20 characters.
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// id: Unique identifier for your button. This ID is returned in the webhook when the button is clicked by the user.
        /// Maximum length: 256 characters.
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Reply Message for your button.
        [JsonProperty("reply")]
        public ReplyMessage Reply { get; set; }
    }
    public class ReplyMessage
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// id: Unique identifier for your reply message.
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// title: title for your reply button.
        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public class InteractiveSection
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Title of the section.
        /// Maximum length: 24 characters.
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Contains a list of rows.    
       [JsonProperty("rows")]
        public Rows[] Rows { get; set; }
    }
    public class Rows
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Title of the row. 
        [JsonProperty("title")]
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Title of the row. 
        public string Title { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Id of the row. 
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/guides/interactive-messages
        /// Description of the row. 
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
