public abstract class Harvester : Entity, IHarvester
{
    protected Harvester(int id, double oreOutput,
        double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput { get; }

    public double EnergyRequirement { get; }

    public override double Produce()
    {
        return this.OreOutput;
    }
}