using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IDictionary<string, double> percentages;
    private IHarvesterFactory factory;

    public HarvesterController(IHarvesterFactory factory, IEnergyRepository energyRepository)
    {
        this.mode = "Full";
        this.energyRepository = energyRepository;
        this.percentages = new Dictionary<string, double>();
        this.factory = factory;
        this.harvesters = new List<IHarvester>();

        this.percentages.Add("Full", 1);
        this.percentages.Add("Half", 0.5);
        this.percentages.Add("Energy", 0.2);
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        foreach (var harvester in harvesters)
        {
            harvester.Broke();
        }

        this.harvesters = harvesters.Where(x => x.Durability >= 0)
            .ToList();

        return string.Format(Constants.ChangeMode, mode);
    }

    public string Produce()
    {
        var percentage = this.percentages[mode];

        var oreOutput = this.harvesters.Sum(x => x.Produce() * percentage);
        var energyRequirement = this.harvesters.Sum(x => x.EnergyRequirement * percentage);

        if (energyRepository.TakeEnergy(energyRequirement))
        {
            this.OreProduced += oreOutput;
        }
        else
        {
            oreOutput = 0;
        }

        return string.Format(Constants.OreOutputToday, oreOutput);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name); ;
    }
}
