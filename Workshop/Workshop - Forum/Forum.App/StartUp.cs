namespace Forum.App
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Contracts;
    using Factories;
    using Forum.App.Models;
    using Forum.Data;
    using Forum.App.Services;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var menu = serviceProvider.GetService<IMainController>();

            Engine engine = new Engine(menu);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            serviceCollection.AddSingleton<ILabelFactory, LabelFactory>();
            serviceCollection.AddSingleton<IMenuFactory, MenuFactory>();
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();

            serviceCollection.AddSingleton<ForumData>();
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<IUserService, UserService>();

            serviceCollection.AddSingleton<ISession, Session>();
            serviceCollection.AddSingleton<IForumViewEngine, ForumViewEngine>();
            serviceCollection.AddSingleton<IMainController, MenuController>();

            serviceCollection.AddTransient<IForumReader, ForumConsoleReader>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
