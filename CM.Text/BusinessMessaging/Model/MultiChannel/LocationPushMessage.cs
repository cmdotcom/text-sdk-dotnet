﻿using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Used to send a location, supported by (most) <see cref="Channel.RCS"/> connections
    /// and <see cref="Channel.WhatsApp"/>.
    /// </summary>
    [PublicAPI]
    public class LocationPushMessage : IRichMessage
    {
        /// <summary>
        /// The location options to send.
        /// </summary>
        [JsonPropertyName("location")]
        public ViewLocationOptions Location { get; set; }
        
        /// <summary>
        /// Contextual properties of the message. Only applicable to <see cref="Channel.WhatsApp"/>
        /// </summary>
        [JsonPropertyName("context")]
        [CanBeNull]
        public MessageContext MessageContext { get; set; }
    }
}
