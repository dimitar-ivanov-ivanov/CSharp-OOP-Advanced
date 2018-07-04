namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyCenter
    {
        string Name { get; }

        int AmountOfMaximumEmergencies { get; set; }

        bool isForRetirement();
    }
}
