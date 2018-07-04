namespace Create_Twitter.Models
{
    using Create_Twitter.Contracts;

    public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void RecieveMessage(string message)
        {
            this.client.WriteTweet(message);
            this.client.SendTweetToServer(message);
        }
    }
}
