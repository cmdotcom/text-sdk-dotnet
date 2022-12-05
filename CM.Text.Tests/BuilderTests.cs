using CM.Text.BusinessMessaging;
using CM.Text.BusinessMessaging.Model;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using FluentAssertions;

namespace CM.Text.Tests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void BuildTest()
        {
            var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");

            var mediaName = "cm.com";
            var mediaUri = "https://avatars3.githubusercontent.com/u/8234794?s=200&v=4";
            var mediaType = "image/png";

            builder
                .WithAllowedChannels(Channel.WhatsApp)
                .WithRichMessage(
                    new MediaMessage(
                        mediaName,
                        mediaUri,
                        mediaType
                    )
                );
            var message = builder.Build();

            message.Should().NotBeNull();
            message.RichContent.Conversation.Should().NotBeNull();
            message.RichContent.Conversation.Length.Should().Be(1);
            var media = (MediaMessage) message.RichContent.Conversation.First();
            media.Media.MediaName.Should().Be(mediaName);
            media.Media.MediaUri.Should().Be(mediaUri);
            media.Media.MimeType.Should().Be(mediaType);
        }
    }
}
