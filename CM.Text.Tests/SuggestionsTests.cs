using System.Text.Json;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using FluentAssertions;

namespace CM.Text.Tests
{
    [TestClass]
    public class SuggestionsTests
    {
        [TestMethod]
        public void SerializationCalendarSuggestionTest()
        {
            var calenderSuggestion = new CalendarSuggestion()
            {
                Calendar = new CalendarOptions()
                {
                    Title = "Appointment selection",
                    Description = "Schedule an appointment with us",
                    EndTime = DateTime.UtcNow,
                    StartTime = DateTime.UtcNow,
                }
            };
            
            var serialized= JsonSerializer.Serialize<SuggestionBase>(calenderSuggestion);

            serialized.Should().NotBeNullOrWhiteSpace();
            
            var deserialized = JsonSerializer.Deserialize<SuggestionBase>(serialized);

            deserialized.Should().BeOfType<CalendarSuggestion>();
            var deserializedCalendarSuggestion = deserialized as CalendarSuggestion;
            deserializedCalendarSuggestion.Should().BeEquivalentTo(calenderSuggestion);
        }
        
        [TestMethod]
        public void SerializationDialSuggestionTest()
        {
            var dialSuggestion = new DialSuggestion()
            {
                Dial = new Dial()
                {
                    PhoneNumber = "0031612345678"
                }
            };
            
            var serialized= JsonSerializer.Serialize<SuggestionBase>(dialSuggestion);

            serialized.Should().NotBeNullOrWhiteSpace();
            
            var deserialized = JsonSerializer.Deserialize<SuggestionBase>(serialized);

            deserialized.Should().BeOfType<DialSuggestion>();
            var deserializedDialSuggestion = deserialized as DialSuggestion;
            deserializedDialSuggestion.Should().BeEquivalentTo(dialSuggestion);
        }
        
        [TestMethod]
        public void SerializationOpenUrlSuggestionTest()
        {
            var openUrlSuggestion = new OpenUrlSuggestion()
            {
                Url = "https://www.cm.com"
            };
            
            var serialized= JsonSerializer.Serialize<SuggestionBase>(openUrlSuggestion);

            serialized.Should().NotBeNullOrWhiteSpace();
            
            var deserialized = JsonSerializer.Deserialize<SuggestionBase>(serialized);

            deserialized.Should().BeOfType<OpenUrlSuggestion>();
            var deserializedOpenUrlSuggestion = deserialized as OpenUrlSuggestion;
            deserializedOpenUrlSuggestion.Should().BeEquivalentTo(openUrlSuggestion);
        }
        
        [TestMethod]
        public void SerializationViewLocationSuggestionTest()
        {
            var viewLocationSuggestion = new ViewLocationSuggestion()
            {
                Location = new ViewLocationOptions()
                {
                    Label = "CM.com headquarters",
                    Latitude = "51.602885",
                    Longitude = "4.7683932",
                    SearchQuery = "CM.com headquarters",
                    Radius = 5
                }
            };
            
            var serialized= JsonSerializer.Serialize<SuggestionBase>(viewLocationSuggestion);

            serialized.Should().NotBeNullOrWhiteSpace();
            
            var deserialized = JsonSerializer.Deserialize<SuggestionBase>(serialized);

            deserialized.Should().BeOfType<ViewLocationSuggestion>();
            var deserializedViewLocationSuggestion = deserialized as ViewLocationSuggestion;
            deserializedViewLocationSuggestion.Should().BeEquivalentTo(viewLocationSuggestion);
        }
        
        [TestMethod]
        public void SerializationReplySuggestionTest()
        {
            var replySuggestion = new ReplySuggestion()
            {
                Label = "Some label",
                PostbackData = "LABEL",
                Description = "Description of the label",
                Media = new MediaContent("Test image", "https://example.com", "image/jpg")
            };
            var serialized= JsonSerializer.Serialize<SuggestionBase>(replySuggestion);

            serialized.Should().NotBeNullOrWhiteSpace();
            
            var deserialized = JsonSerializer.Deserialize<SuggestionBase>(serialized);

            deserialized.Should().BeOfType<ReplySuggestion>();
            var deserializedReplySuggestion = deserialized as ReplySuggestion;
            deserializedReplySuggestion.Should().BeEquivalentTo(replySuggestion);
        }
    }
}
