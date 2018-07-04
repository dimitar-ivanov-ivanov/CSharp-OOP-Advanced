namespace BarrackWars.Core.Commands
{
    using BarrackWars.Attributes;
    using BarrackWars.Contracts;

    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public ReportCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var output = this.repository.Statistics;
            return output;
        }
    }
}
