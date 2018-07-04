namespace Forum.App.Commands
{
    using Forum.App.Contracts;

    public class NextPageCommand : ICommand
    {
        private ISession session;

        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var menu = this.session.CurrentMenu;
            if (menu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(true);
            }
            return menu;
        }
    }
}
