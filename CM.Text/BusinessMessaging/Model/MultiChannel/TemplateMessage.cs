﻿using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Used to send a template message, at this moment only supported in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    [PublicAPI]
    public class TemplateMessage : IRichMessage
    {
        /// <summary>
        /// The Content of the WhatsApp template message
        /// </summary>
        /// <remarks>Templates need to be configured by CM and approved by WhatsApp before it is possible
        /// to send these messages.
        /// </remarks>
        [JsonPropertyName("template")]
        public TemplateMessageContent Content { get; set; }
    }
}
