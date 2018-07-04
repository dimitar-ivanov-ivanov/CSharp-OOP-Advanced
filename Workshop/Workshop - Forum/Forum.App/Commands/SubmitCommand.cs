namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            var replyText = args[0];

            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException("Cannot add an empty reply!");
            }

            var postId = int.Parse(args[1]);
            var authorId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, authorId);

            return this.session.Back();
        }
    }
}
