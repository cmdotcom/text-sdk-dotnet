using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     A suggestion, used in <see cref="Channel.RCS" />.
    ///     When the user clicks on the icon, it opens the calendar app of the user to add
    ///     the new appointment.
    /// </summary>
    [PublicAPI]
    public class CalendarSuggestion : SuggestionBase
    {
        /// <summary>
        ///     The options of the agenda item
        /// </summary>
        [JsonPropertyName("calendar")]
        public CalendarOptions Calendar { get; set; }
    }
}
