namespace Kings_Gambit_Extended.Models
{
    using System;

    public class King : Unit
    { 
        public King(string name) : base(name)
        {
        }

        public event EventHandler UnderAttack;

        public override void RespondToAttack(object sender,EventArgs args)
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if(UnderAttack != null)
            {
                UnderAttack.Invoke(this, args);
            }
        }
    }
}
