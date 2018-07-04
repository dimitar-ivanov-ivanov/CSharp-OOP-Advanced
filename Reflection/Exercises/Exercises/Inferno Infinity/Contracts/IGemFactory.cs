namespace Inferno_Infinity.Contracts
{
    public interface IGemFactory
    {
       IGem CreateGem(string gemType, string gemClarityName);
    }
}
