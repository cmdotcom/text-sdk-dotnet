using System;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     Contains information for a <see cref="CalendarSuggestion" />.
    /// </summary>
    [PublicAPI]
    public class CalendarOptions
    {
        /// <summary>
        ///     The end of the appointment.
        /// </summary>
        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        /// <summary>
        ///     The start of the appointment.
        /// </summary>
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        ///     The description which will appear in the calendar app
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     The title of the appointment which will appear in the calendar app
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
