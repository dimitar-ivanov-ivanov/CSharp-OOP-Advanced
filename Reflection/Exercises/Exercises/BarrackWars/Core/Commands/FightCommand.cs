namespace BarrackWars.Core.Commands
{
    using BarrackWars.Attributes;
    using BarrackWars.Contracts;
    using System;

    public class FightCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public FightCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "";
        }
    }
}
