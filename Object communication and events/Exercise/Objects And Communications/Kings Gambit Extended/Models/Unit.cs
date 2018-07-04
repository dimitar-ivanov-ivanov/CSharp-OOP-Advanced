namespace Kings_Gambit_Extended.Models
{
    using Kings_Gambit_Extended.Contracts;
    using System;

    public abstract class Unit : IUnit
    {
        private string name;

        protected Unit(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public abstract void RespondToAttack(object sender, EventArgs args);
    }
}
