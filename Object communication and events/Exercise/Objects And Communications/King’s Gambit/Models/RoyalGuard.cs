namespace King_s_Gambit.Models
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
