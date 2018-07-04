namespace Forum.App.Commands
{
    using Forum.App.Contracts;
    using System;

    public class SignUpCommand : ICommand
    {
        private const string ErrorMessage = "Invalid username or password!";

        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var validUsername = !string.IsNullOrEmpty(username) &&
                username.Length > 4;

            var validPassword = !string.IsNullOrEmpty(password) &&
                password.Length > 4;

            if (!validPassword || !validUsername)
            {
                throw new ArgumentException(ErrorMessage);
            }

            var sucess = userService.TrySignUpUser(username, password);

            if (!sucess)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return menuFactory.CreateMenu("MainMenu");
        }
    }
}
