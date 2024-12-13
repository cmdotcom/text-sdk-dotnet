using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

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
            Conversation = null;
            Suggestions = null;
        }

        /// <summary>
        ///     The messages.
        /// </summary>
        [JsonPropertyName("conversation")]
        public RichMessage[] Conversation { get; set; }

        /// <summary>
        ///     The suggestions
        /// </summary>
        [JsonPropertyName("suggestions")]
        public SuggestionBase[] Suggestions { get; set; }

        /// <summary>
        ///     Adds a message, such as a <see cref="RichCard" /> or <see cref="TextMessage" />.
        /// </summary>
        /// <param name="part"></param>
        public void AddConversationPart(RichMessage part)
        {
            if (Conversation == null)
                Conversation = new[] {part};
            else
            {
                var newArr = Conversation;
                Array.Resize(ref newArr, Conversation.Length + 1);
                newArr[newArr.Length - 1] = part;
                Conversation = newArr;
            }
        }

        /// <summary>
        ///     Adds a suggestion
        /// </summary>
        /// <param name="suggestion"></param>
        public void AddSuggestion(SuggestionBase suggestion)
        {
            if (Suggestions == null)
                Suggestions = new[] {suggestion};
            else
            {
                var newArr = Suggestions;
                Array.Resize(ref newArr, Suggestions.Length + 1);
                newArr[newArr.Length - 1] = suggestion;
                Suggestions = newArr;
            }
        }
    }
}
