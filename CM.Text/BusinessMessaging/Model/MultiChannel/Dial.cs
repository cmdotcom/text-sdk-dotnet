﻿using JetBrains.Annotations;
using System.Text.Json.Serialization;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Contains information for a <see cref="DialSuggestion" />
    /// </summary>
    [PublicAPI]
    public class Dial
    {
        /// <summary>
        ///     The number to call (in international format)
        /// </summary>
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
