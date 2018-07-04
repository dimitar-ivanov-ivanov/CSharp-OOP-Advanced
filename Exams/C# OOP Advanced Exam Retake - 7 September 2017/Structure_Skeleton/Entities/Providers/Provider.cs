public abstract class Provider : Entity,IProvider
{
    protected Provider(int id,double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput { get; }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override double Produce()
    {
        return this.EnergyOutput;
    }
}