using System.Text.Json;
using CM.Text.BusinessMessaging;
using CM.Text.BusinessMessaging.Model;
using FluentAssertions;

namespace CM.Text.Tests
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
    }
}
