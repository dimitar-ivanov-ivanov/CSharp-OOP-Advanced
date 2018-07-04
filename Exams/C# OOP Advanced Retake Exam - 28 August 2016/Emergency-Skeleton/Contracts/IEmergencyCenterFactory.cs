namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyCenterFactory
    {
        IEmergencyCenter CreateFactory(string type, string name, int amountOfMaximumEmergencies);
    }
}
