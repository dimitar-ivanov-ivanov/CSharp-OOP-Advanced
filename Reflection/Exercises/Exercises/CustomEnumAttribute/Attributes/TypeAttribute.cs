namespace CustomEnumAttribute.Attributes
{
    using System;

    public class TypeAttribute : Attribute
    {
        private string type;
        private string category;
        private string description;

        public string Type { get => type; set => type = value; }

        public string Category { get => category; set => category = value; }

        public string Description { get => description; set => description = value; }

        public override string ToString()
        {
            return $"Type = {this.Type}, {this.Description}";
        }
    }
}