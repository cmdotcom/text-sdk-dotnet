using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// Contains information for a <see cref="CalendarSuggestion"/>.
    /// </summary>
    [PublicAPI]
    public class CalendarOptions {

        /// <summary>
        /// The title of the appointment which will appear in the calendar app
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// The description which will appear in the calendar app
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// The start of the appointment.
        /// </summary>
        [JsonProperty("startTime")]
        public DateTime StartTime;
        /// <summary>
        /// The end of the appointment.
        /// </summary>
        [JsonProperty("endTime")]
        public DateTime EndTime;
    }
}
