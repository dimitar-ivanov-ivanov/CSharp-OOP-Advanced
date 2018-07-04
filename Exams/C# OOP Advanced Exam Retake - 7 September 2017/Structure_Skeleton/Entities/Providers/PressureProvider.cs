public class PressureProvider : Provider
{
    private const double DurabilityDecrease = 300;
    private const double EnergyOutputMultiplier = 2;

    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput * EnergyOutputMultiplier)
    {
        this.Durability -= DurabilityDecrease;
    }
}