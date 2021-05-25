using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Object containing information about an image, a video or an audio file.
    /// </summary>
    [PublicAPI]
    public class MediaContent
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public MediaContent()
        {
        }

        /// <summary>
        ///     Constructor which sets values
        /// </summary>
        /// <param name="mediaName"></param>
        /// <param name="mediaUri"></param>
        /// <param name="mimeType"></param>
        public MediaContent(string mediaName, string mediaUri, string mimeType)
        {
            this.MediaName = mediaName;
            this.MediaUri = mediaUri;
            this.MimeType = mimeType;
        }

        /// <summary>
        ///     The name of the image, audio or video.
        /// </summary>
        [JsonProperty("mediaName")]
        public string MediaName { get; set; }

        /// <summary>
        ///     The location of the image, audio or video.
        /// </summary>
        [JsonProperty("mediaUri")]
        public string MediaUri { get; set; }

        /// <summary>
        ///     The mimetype of the image, audio or video.
        /// </summary>
        [JsonProperty("mimeType")]
        public string MimeType { get; set; }
    }
}
