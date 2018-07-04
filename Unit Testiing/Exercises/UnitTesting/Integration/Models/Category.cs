namespace Integration.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Integration.Contracts;

    public class Category : ICategory
    {
        private string name;
        private ICategory parent;
        private IList<IUser> users;
        private IList<ICategory> children;

        public Category(string name)
        {
            this.Name = name;
            this.Users = new List<IUser>();
            this.children = new List<ICategory>();
        }

        public Category(string name, IList<IUser> users)
            : this(name)
        {
            this.Users = users;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) ||
                   string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Cannot create category without a name");
                }

                this.name = value;
            }
        }

        public IList<IUser> Users
        {
            get { return this.users; }
            private set { this.users = value; }
        }

        public ICategory Parent
        {
            get { return this.parent; }
            private set { this.parent = value; }
        }

        public IList<ICategory> Children
        {
            get { return this.children; }
            private set { this.children = value; }
        }

        public void MoveUsersToParent()
        {
            if (this.Parent == null)
            {
                return;
            }

            foreach (var user in this.Users)
            {
                this.Parent.Users.Add(user);
            }
        }

        public void RemoveChild(string name)
        {
            var childToRemove = this.Children.FirstOrDefault(x => x.Name == name);
            this.Children.Remove(childToRemove);
        }

        public void AddChild(ICategory category)
        {
            this.Children.Add(category);
            category.SetParent(this);
        }

        public void AddUser(IUser user)
        {
            this.Users.Add(user);
            user.AddCategory(this);
        }

        public void SetParent(ICategory category)
        {
            this.Parent = category;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Category;
            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override string ToString()
        {
            return this.Name;
        }
    }
}
