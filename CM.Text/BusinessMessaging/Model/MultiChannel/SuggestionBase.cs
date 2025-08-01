﻿using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Suggestions can be used in several channels, not all channels
    ///     support all suggestions.
    ///
    ///     Requires a json derived type for serialization to work
    /// </summary>
    [PublicAPI]
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "action")]
    [JsonDerivedType(typeof(CalendarSuggestion), "CreateCalendarEvent")]
    [JsonDerivedType(typeof(DialSuggestion), "Dial")]
    [JsonDerivedType(typeof(OpenUrlSuggestion), "openUrl")]
    [JsonDerivedType(typeof(ReplySuggestion), "reply")]
    [JsonDerivedType(typeof(ViewLocationSuggestion), "viewLocation")]
    public abstract class SuggestionBase
    {
        /// <summary>
        ///     The text the end user will see
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        ///     When the item is selected and the postback data is set, then the Postback data will be
        ///     sent in a MO instead of the <see cref="Label" />.
        /// </summary>
        [JsonPropertyName("postbackdata")]
        public string PostbackData { get; set; }
    }
}
