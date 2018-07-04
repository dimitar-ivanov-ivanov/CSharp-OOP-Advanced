namespace Integration.Models
{
    using System.Collections.Generic;
    using Integration.Contracts;

    public class User : IUser
    {
        private string name;
        private IList<ICategory> categories;

        public User(string name)
        {
            this.name = name;
            this.Categories = new List<ICategory>();
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public IList<ICategory> Categories
        {
            get { return this.categories; }
            private set { this.categories = value; }
        }

        public void AddCategory(ICategory category)
        {
            this.Categories.Add(category);
        }

        public void RemoveCategory(ICategory category)
        {
            this.Categories.Remove(category);

            if(category.Parent != null)
            {
                this.categories.Add(category.Parent);
            }
        }
    }
}
