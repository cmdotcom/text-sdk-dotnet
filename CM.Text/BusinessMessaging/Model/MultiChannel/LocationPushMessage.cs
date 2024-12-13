using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Used to send a location, supported by (most) <see cref="Channel.RCS"/> connections
    /// and <see cref="Channel.WhatsApp"/>.
    /// </summary>
    [PublicAPI]
    public class LocationPushMessage : RichMessage
    {
        /// <summary>
        /// The location options to send.
        /// </summary>
        [JsonPropertyName("location")]
        public ViewLocationOptions Location { get; set; }
    }
}
