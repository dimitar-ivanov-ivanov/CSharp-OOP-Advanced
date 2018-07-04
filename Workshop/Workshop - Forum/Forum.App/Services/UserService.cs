namespace Forum.App.Services
{
    using Forum.App.Contracts;
    using Forum.Data;
    using Forum.DataModels;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                throw new ArgumentException($"User withd id {userId} not found!");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            return this.GetUserById(userId).Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            var user = this.forumData.Users.FirstOrDefault(x => x.Username == username &&
                                                                x.Password == password);
            if(user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            var userAlredyExists = this.forumData.Users
                .Any(x => x.Username == username);

            if (userAlredyExists)
            {
                throw new ArgumentException("Username taken!");
            }

            var userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            var user = new User(userId, username, password);

            forumData.Users.Add(user);
            forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
