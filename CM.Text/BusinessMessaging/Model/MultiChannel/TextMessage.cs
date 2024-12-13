using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A regular text message, replaces the <see cref="Message.Body" /> for channels that support rich content
    ///     (all channels except <see cref="Channel.SMS" />, <see cref="Channel.Voice" /> and <see cref="Channel.Push" /> at this moment)
    /// </summary>
    [PublicAPI]
    public class TextMessage : RichMessage
    {
        /// <summary>
        ///     Construct an empty text message.
        /// </summary>
        public TextMessage()
        {
        }

        /// <summary>
        ///     Construct a text message and initialise the <see cref="Text" />
        /// </summary>
        /// <param name="text"></param>
        public TextMessage(string text)
        {
            Text = text;
        }

        /// <summary>
        ///     A plain text message, when used it replaces the 'SMS' body text.
        ///     In <see cref="Channel.RCS"/>, when used in combination with an header and/or media this will be set as the text of a rich card.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        /// <summary>
        ///     Tag to send important and/or personally relevant 1:1 updates to recipients. E.g. to notify a recipient of an update on a recent purchase.
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        /// <summary>
        ///     The suggestions of a text message.
        /// </summary>
        [JsonPropertyName("suggestions")]
        public SuggestionBase[] Suggestions { get; set; }
    }
}
