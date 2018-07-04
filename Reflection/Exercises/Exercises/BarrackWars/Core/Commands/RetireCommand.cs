namespace BarrackWars.Core.Commands
{
    using BarrackWars.Attributes;
    using BarrackWars.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public RetireCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
