namespace Inferno_Infinity.Contracts
{
    using Inferno_Infinity.Enums;

    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        GemClarity GemClarity { get; }

        IGem CalculatedActivatedClarity();
    }
}
