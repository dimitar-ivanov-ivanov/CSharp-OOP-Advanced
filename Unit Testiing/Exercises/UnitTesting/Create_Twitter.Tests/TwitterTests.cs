using Create_Twitter.Contracts;
using Create_Twitter.Models;
using Moq;
namespace Create_Twitter.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TwitterTests
    {
        private const string Test = "Test";

        [Test]
        public void TweetInvokesClientToWriteMessage()
        {
            var client = new Mock<IClient>();
            client.Setup(x => x.WriteTweet(It.IsAny<string>()));

            var tweet = new Tweet(client.Object);

            tweet.RecieveMessage(Test);

            client.Verify(c => c.WriteTweet(Test), Times.Once,
                "Tweet doesnt make client write the tweet.");
        }

        [Test]
        public void TweetInvokesClientToSendToServer()
        {
            var client = new Mock<IClient>();
            client.Setup(x => x.SendTweetToServer(It.IsAny<string>()));

            var tweet = new Tweet(client.Object);

            tweet.RecieveMessage(Test);

            client.Verify(c => c.SendTweetToServer(Test), Times.Once,
                "Tweet doesnt make client send the tweet.");
        }

        [Test]
        public void ClientInvokesRepositoryToSaveTweet()
        {
            var repositoy = new Mock<IRepository>();
            repositoy.Setup(x => x.SaveRepository(It.IsAny<string>()));

            var client = new MicrowaveOven(repositoy.Object);

            client.SendTweetToServer(Test);

            repositoy.Verify(c => c.SaveRepository(Test), Times.Once,
                "Client sending to server is invalid."); 
        }
    }
}
