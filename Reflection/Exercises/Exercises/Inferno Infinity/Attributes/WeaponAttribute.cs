namespace Inferno_Infinity.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property,
        Inherited = true)]
    public class WeaponAttribute : Attribute
    {
        private string author;
        private int revision;
        private string description;
        private string[] reviewers;

        public WeaponAttribute(string author, int revision, string description, string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public string Author { get => author; set => author = value; }

        public int Revision { get => revision; set => revision = value; }

        public string Description { get => description; set => description = value; }

        public string[] Reviewers { get => reviewers; set => reviewers = value; }
    }
}
