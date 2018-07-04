namespace Integration.Contracts
{
    using System.Collections.Generic;

    public interface IUser
    {
        string Name { get; }

        IList<ICategory> Categories { get; }

        void RemoveCategory(ICategory category);

        void AddCategory(ICategory category);
    }
}
