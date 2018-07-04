namespace Integration.Contracts
{
    using System.Collections.Generic;

    public interface IController
    {
        void AddCategory(string name);

        void AddCategory(IEnumerable<string> names);

        void RemoveCategory(string name);

        void RemoveCategory(IEnumerable<string> names);

        void AddChild(ICategory parent, string childName);

        void AddUser(ICategory category, IUser user);
    }
}
