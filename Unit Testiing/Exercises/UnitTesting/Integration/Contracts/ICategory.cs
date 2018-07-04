namespace Integration.Contracts
{
    using System.Collections.Generic;

    public interface ICategory
    {
        string Name { get; }

        IList<IUser> Users { get; }

        ICategory Parent { get; }

        IList<ICategory> Children { get; }

        void MoveUsersToParent();

        void RemoveChild(string name);

        void AddChild(ICategory category);

        void AddUser(IUser user);

        void SetParent(ICategory category);
    }
}
