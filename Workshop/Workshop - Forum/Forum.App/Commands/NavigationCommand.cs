namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public abstract class NavigationCommand : ICommand
    {
        private IMenuFactory menuFactory;

        protected NavigationCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var commandName = this.GetType().Name;
            var menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            var menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }
    }
}
