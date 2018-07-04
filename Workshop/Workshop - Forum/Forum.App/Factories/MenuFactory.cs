namespace Forum.App.Factories
{
    using Forum.App.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var menuType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                //Possible bug
                throw new InvalidOperationException($"{menuName} is not a menu!");
            }

            var ctorParams = menuType.GetConstructors()
                .First().GetParameters();

            var args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            return (IMenu)Activator.CreateInstance(menuType, args);
        }
    }
}
