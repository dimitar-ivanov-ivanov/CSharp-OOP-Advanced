namespace Emergency_Skeleton.Contracts
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;
    using System.Collections.Generic;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel Level { get; }

        RegistrationTime Time { get; }

        KeyValuePair<string, int> GetSecondaryParameter();
    }
}
