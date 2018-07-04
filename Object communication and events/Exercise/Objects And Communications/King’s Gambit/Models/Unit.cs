namespace King_s_Gambit.Models
{
    using King_s_Gambit.Contracts;
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
