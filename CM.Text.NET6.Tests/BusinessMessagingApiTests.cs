using CM.Text.BusinessMessaging;
using CM.Text.BusinessMessaging.Model;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using FluentAssertions;

namespace CM.Text.NET6.Tests
{
    [TestClass]
    public class BusinessMessagingApiTests
    {
        [TestMethod]
        public void TestPostBody()
        {
            var guid = Guid.NewGuid();
            var message = "This is a unit test";
            var sender = "CM.com";
            var reference = "ReferenceForMeToFind";
            var number1 = "0031612345678";
            var number2 = "0031612345679";

            var data = BusinessMessagingApi.GetHttpPostBody(guid, message, sender,
                new[] {number1, number2}, reference);

            data.Should().NotBeNull();
            //Simple to check if all values survived our logic
            data.Should().Contain(guid.ToString());
            data.Should().Contain(message);
            data.Should().Contain(sender);
            data.Should().Contain(reference);
            data.Should().Contain(number1);
            data.Should().Contain(number2);
        }

        [TestMethod]
        public void TestRichPostBody()
        {
            var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");

            var mediaName = "cm.com icon";
            var mediaUri = "https://avatars3.githubusercontent.com/u/8234794";
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

            Guid fakeApiKey = Guid.NewGuid();
            var data = BusinessMessagingApi.GetHttpPostBody(fakeApiKey, message);

            data.Should().NotBeNull();
            //Simple to check if all values survived our logic
            data.Should().Contain(fakeApiKey.ToString(), "the api key should be present in the body");
            data.Should().Contain(mediaName, "the media name needs to be sent");
            data.Should().Contain(mediaType, "the media type has to be sent");
            data.Should().Contain(mediaUri, "the media url has to be sent");
        }


        [TestMethod]
        public void TestResponseBody()
        {
            var guid = Guid.NewGuid();
            // Arrange
            string message = @"{
                ""messages"": [{
                    ""to"": ""0031612345678"",
                    ""parts"": 1,
                    ""status"": ""Accepted"",
                    ""reference"": ""test-reference-1"",
                    ""messageErrorCode"": 0,
                    ""messageDetails"": null
                }],
                ""details"": ""Created 1 message(s)"",
                ""errorCode"": 0
            }";


            var data = BusinessMessagingApi.GetTextApiResult(message);

            data.Should().NotBeNull();
            //Simple to check if all values survived our logic
            data.details.Should().NotBeNull();
            data.details.First().reference.Should().Be("test-reference-1");
            data.details.First().status.Should().Be("Accepted");
            data.details.First().to.Should().Be("0031612345678");
            data.details.First().parts.Should().Be(1);
            data.details.First().details.Should().BeNull();
        }
    }
}
