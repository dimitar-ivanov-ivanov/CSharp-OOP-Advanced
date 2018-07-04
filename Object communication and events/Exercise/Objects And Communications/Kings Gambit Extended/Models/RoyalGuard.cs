namespace Kings_Gambit_Extended.Models
{
    using System;

    public class RoyalGuard : Unit
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void RespondToAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
