namespace Create_Twitter.Models
{
    using Create_Twitter.Contracts;
    using System;

    public class MicrowaveOven : IClient
    {
        private IRepository repository;

        public MicrowaveOven(IRepository repository)
        {
            this.repository = repository;
        }

        public void SendTweetToServer(string message)
        {
            repository.SaveRepository(message);
        }

        public void WriteTweet(string message)
        {
            Console.WriteLine(message);
        }
    }
}
