using System.Text.Json;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using FluentAssertions;

namespace CM.Text.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializeTextTest()
        {
            var textMessage = new TextMessage("testing correct serialization");
            var serialized= JsonSerializer.Serialize<IRichMessage>(textMessage);

            serialized.Should().NotBeNullOrWhiteSpace();
            serialized.Should().Contain("\"$type\":\"TextMessage\"");
        }
    }
}
