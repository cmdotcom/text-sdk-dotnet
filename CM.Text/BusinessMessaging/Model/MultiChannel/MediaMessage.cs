using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// A message, which can be used for rich content channels such as
    /// <see cref="Channel.RCS"/>, <see cref="Channel.WhatsApp"/> and <see cref="Channel.Viber"/>.
    /// </summary>
    [PublicAPI]
    public class MediaMessage : IRichMessage {
        /// <summary>
        /// The image or video of the message.
        /// </summary>
        [JsonProperty("media")]
        public MediaContent Media { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MediaMessage() { }

        /// <summary>
        /// Constructor setting values.
        /// </summary>
        /// <param name="mediaName"></param>
        /// <param name="mediaUri"></param>
        /// <param name="mimeType"></param>
        public MediaMessage(string mediaName, string mediaUri, string mimeType) {
            Media = new MediaContent(mediaName, mediaUri, mimeType);
        }
    }
}
