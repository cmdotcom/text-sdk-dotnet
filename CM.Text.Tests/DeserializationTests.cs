using System.Text.Json;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using FluentAssertions;

namespace CM.Text.Tests
{
    [TestClass]
    public class DeserializationTests
    {
        [TestMethod]
        public void DeserializeTextTest()
        {
            var textMessage = "{\"$type\":\"TextMessage\",\"text\":\"testing correct deserialization\",\"tag\":null,\"suggestions\":null}";
            var deserialized = JsonSerializer.Deserialize<IRichMessage>(textMessage);

            deserialized.Should().BeOfType<TextMessage>();
            var deserializedTextMessage = deserialized as TextMessage;
            deserializedTextMessage!.Text.Should().Be("testing correct deserialization");
        }
    }
}


