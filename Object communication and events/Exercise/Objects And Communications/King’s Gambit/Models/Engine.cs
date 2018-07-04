namespace King_s_Gambit.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private King king;
        private IList<Footman> footmen;
        private IList<RoyalGuard> royalGuards;

        private const string TerminatringCommand = "End";

        public Engine()
        {
            GetUnits();
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while(input != TerminatringCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var command = args[0];

                switch (command)
                {
                    case "Attack":
                        king.RespondToAttack(null,new EventArgs());
                        break;
                    case "Kill":
                        var guard = this.royalGuards.FirstOrDefault(x => x.Name == args[1]);
                        var footman = this.footmen.FirstOrDefault(x => x.Name == args[1]);
                        
                        if(guard != null)
                        {
                            this.king.UnderAttack -= guard.RespondToAttack;
                            this.royalGuards.Remove(guard);
                        }

                        if(footman != null)
                        {
                            this.king.UnderAttack -= footman.RespondToAttack;
                            this.footmen.Remove(footman);
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private void GetUnits()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.king = new King(args[0]);

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.royalGuards = args.Select(x => new RoyalGuard(x)).ToList();

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.footmen = args.Select(x => new Footman(x)).ToList();

            foreach (var guard in this.royalGuards)
            {
                king.UnderAttack += guard.RespondToAttack;
            }

            foreach (var footman in this.footmen)
            {
                king.UnderAttack += footman.RespondToAttack;
            }
        }
    }
}