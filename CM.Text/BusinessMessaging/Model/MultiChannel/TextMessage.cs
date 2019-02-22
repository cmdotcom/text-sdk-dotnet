﻿using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// A regular text message, replaces the <see cref="Message.Body"/> for channels
    /// that support rich content (all channels except <see cref="Channel.SMS"/>, <see cref="Channel.Voice"/>
    /// and <see cref="Channel.Push"/> at this moment)
    /// </summary>
    [PublicAPI]
    public class TextMessage : IRichMessage {
        /// <summary>
        /// The text to display.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// Construct an empty text message.
        /// </summary>
        public TextMessage() { }
        /// <summary>
        /// Construct a text message and initialise the <see cref="Text"/>
        /// </summary>
        /// <param name="text"></param>
        public TextMessage(string text) {
            Text = text;
        }
    }
}
