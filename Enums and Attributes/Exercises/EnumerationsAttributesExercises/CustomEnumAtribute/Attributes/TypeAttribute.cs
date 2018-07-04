namespace CustomEnumAtribute.Attributes
{
    using System;

    public class TypeAttribute : Attribute
    {
        private string type;
        private string category;
        private string description;

        public string Type => type;
        public string Category => category;
        public string Description => description;

        public TypeAttribute(string type,string category,string description)
        {
            this.type = type;
            this.category = category;
            this.description = description;
        }

        public override string ToString()
        {
            return $"Type = {this.type}, Description = {this.description}";
        }
    }
}
