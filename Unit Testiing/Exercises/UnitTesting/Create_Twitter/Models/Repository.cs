namespace Create_Twitter.Models
{
    using Create_Twitter.Contracts;
    using System.Collections.Generic;

    public class Repository : IRepository
    {
        private IList<string> messages;

        public Repository(IList<string> messages)
        {
            this.messages = messages;
        }

        public void SaveRepository(string message)
        {
            this.messages.Add(message);
        }
    }
}
