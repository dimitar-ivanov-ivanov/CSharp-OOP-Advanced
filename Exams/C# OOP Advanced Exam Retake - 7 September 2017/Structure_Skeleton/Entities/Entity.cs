public abstract class Entity : IEntity
{
    private const double InitialDurability = 1000;
    private const double DurabilityLost = 100;

    protected Entity(int id)
    {
        ID = id;
        Durability = InitialDurability;
    }

    public int ID { get; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityLost;
    }

    public abstract double Produce();

    public override string ToString()
    {
        return $"{this.GetType().Name}\n" +
               $"Durability: {this.Durability}";
    }
}
