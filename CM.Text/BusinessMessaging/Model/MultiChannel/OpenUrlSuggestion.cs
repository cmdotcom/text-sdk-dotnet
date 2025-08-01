﻿using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     This is used to give the user an option to open a link.
    /// </summary>
    /// <remarks>
    ///     For <see cref="Channel.RCS" /> this can be an in-app link,
    ///     which will only be shown when the app is installed.
    /// </remarks>
    [PublicAPI]
    public class OpenUrlSuggestion : SuggestionBase
    {
        /// <summary>
        ///     The url the end user can open
        /// </summary>
        /// <remarks>
        ///     For <see cref="Channel.RCS" /> this can be an in-app link,
        ///     which will only be shown when the app is installed.
        /// </remarks>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
