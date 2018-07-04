public abstract class Ammunition : IAmmunition
{
    private const double WeightMultiplier = 100;

    protected Ammunition(double weight)
    {
        Weight = weight;
        WearLevel = this.Weight * WeightMultiplier;
    }

    public string Name => this.GetType().Name;

    public double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= WearLevel;
    }
}
