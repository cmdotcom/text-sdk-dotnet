using System;
using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Can be used by channels that support rich content (all channels except <see cref="Channel.SMS" />,
    ///     <see cref="Channel.Voice" /> and <see cref="Channel.Push" /> at this moment)
    /// </summary>
    [PublicAPI]
    public class RichContent
    {
        /// <summary>
        ///     Initializes a rich content object
        /// </summary>
        public RichContent()
        {
            this.Conversation = null;
            this.Suggestions = null;
        }

        /// <summary>
        ///     The messages.
        /// </summary>
        [JsonPropertyName("conversation")]
        public IRichMessage[] Conversation { get; set; }

        /// <summary>
        ///     The suggestions
        /// </summary>
        [JsonPropertyName("suggestions")]
        public SuggestionBase[] Suggestions { get; set; }

        /// <summary>
        ///     Adds a message, such as a <see cref="RichCard" /> or <see cref="TextMessage" />.
        /// </summary>
        /// <param name="part"></param>
        public void AddConversationPart(IRichMessage part)
        {
            if (this.Conversation == null)
                this.Conversation = new[] {part};
            else
            {
                var newArr = this.Conversation;
                Array.Resize(ref newArr, this.Conversation.Length + 1);
                newArr[newArr.Length - 1] = part;
                this.Conversation = newArr;
            }
        }

        /// <summary>
        ///     Adds a suggestion
        /// </summary>
        /// <param name="suggestion"></param>
        public void AddSuggestion(SuggestionBase suggestion)
        {
            if (this.Suggestions == null)
                this.Suggestions = new[] {suggestion};
            else
            {
                var newArr = this.Suggestions;
                Array.Resize(ref newArr, this.Suggestions.Length + 1);
                newArr[newArr.Length - 1] = suggestion;
                this.Suggestions = newArr;
            }
        }
    }
}
