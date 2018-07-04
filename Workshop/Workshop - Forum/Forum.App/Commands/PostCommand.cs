namespace Forum.App.Commands
{
    using System;
    using Forum.App.Contracts;

    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var userId = this.session.UserId;
            var title = args[0];
            var category = args[1];
            var content = args[2];

            var validTitle = !string.IsNullOrWhiteSpace(title);
            var validCategory = !string.IsNullOrWhiteSpace(category);
            var validContent = !string.IsNullOrWhiteSpace(content);

            if(!validTitle || !validCategory || !validContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            var postId = this.postService.AddPost(userId, title, category, content);

            this.session.Back();
            var viewPostMenu = this.commandFactory.CreateCommand("ViewPostMenu");

            if(viewPostMenu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return viewPostMenu.Execute(postId.ToString());
        }
    }
}
