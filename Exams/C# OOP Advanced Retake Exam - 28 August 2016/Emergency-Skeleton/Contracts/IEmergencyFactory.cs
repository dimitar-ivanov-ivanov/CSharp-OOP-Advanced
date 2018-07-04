namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyFactory
    {
        IEmergency CreateEmergency(string type, string description, string level, string registrationTimeStr, string secondary);
    }
}
