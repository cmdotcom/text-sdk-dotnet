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

        [TestMethod]
        public void DeserializeTemplateMessageWithTypeTest()
        {
            var richContentJson =
                "{\"conversation\": [{\"template\": {\"whatsapp\": {\"namespace\": \"some_identifier\",\"element_name\": \"image__link\",\"language\": {\"code\": \"en\",\"policy\": \"deterministic\"},\"components\": [{\"type\": \"header\",\"parameters\": [{\"type\": \"image\",\"media\": {\"mediaUri\": \"https://example.com/image.png\",\"mimeType\": \"image/jpeg\"}}]},{\"type\": \"body\",\"parameters\": [{\"type\": \"text\",\"text\": \"testing\"}]},{\"type\": \"button\",\"sub_type\": \"url\",\"index\": \"0\",\"parameters\": [{\"type\": \"text\",\"text\": \"whatsapp\"}]}]}}}]}";
            var deserialized = JsonSerializer.Deserialize<RichContent>(richContentJson);
            deserialized.Should().NotBeNull();
            deserialized!.Conversation.FirstOrDefault().Should().BeOfType<TemplateMessage>();
        }

        [TestMethod]
        public void DeserializeTextMessageWithTypeTest()
        {
            var richContentJson =
                "{\"conversation\": [{\"text\": \"testing\"}]}";
            var deserialized = JsonSerializer.Deserialize<RichContent>(richContentJson);
            deserialized.Should().NotBeNull();
            deserialized!.Conversation.FirstOrDefault().Should().BeOfType<TextMessage>();

            var message = deserialized.Conversation.First();
        }
    }
}


