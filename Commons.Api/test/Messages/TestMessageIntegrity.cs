using Commons.Api.Configuration;
using Commons.Api.Messages;
using Microsoft.Extensions.Options;
using Xunit;

namespace Commons.Api.XTests.Messages
{
    public class TestMessageIntegrity
    {
        [Fact]
        public void TestEncode()
        {
            //Given
            var secret = "SECRET";
            var key = "KEY";
            var messageIntegrity = new HashedMessageIntegrity(secret);
            //When
            var encodedKey = messageIntegrity.Encode(key);
            Assert.NotEmpty(encodedKey);
            //Then
            var result = messageIntegrity.Verify(encodedKey);
            Assert.True(result);
        }

        [Fact]
        public void TestOptions()
        {
            //Given
            var config = new BaseApplicationConfiguration();   
            config.ApplicationSalt = "SECRET";
            var key = "KEY";
            var options = Options.Create(config);
            var messageIntegrity = new HashedMessageIntegrity(options);
             //When
            var encodedKey = messageIntegrity.Encode(key);
            Assert.NotEmpty(encodedKey);
            //Then
            var result = messageIntegrity.Verify(encodedKey);
            Assert.True(result);
        }
    }
}