namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length)
                + "Menu";
          
            var menu = this.menuFactory.CreateMenu(menuName);

            if(menu is IIdHoldingMenu idHoldingMenu)
            {
                var postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
