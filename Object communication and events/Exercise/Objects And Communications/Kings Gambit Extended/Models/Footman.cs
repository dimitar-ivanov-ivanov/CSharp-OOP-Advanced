namespace Kings_Gambit_Extended.Models
{
    using System;

    public class Footman : Unit
    {
        public Footman(string name) : base(name)
        {
        }

        public override void RespondToAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
