namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyManagementSystem
    {
        string RegisterPropertyEmergency(string description, string level, string registrationTime, string secondary);

        string RegisterHealthEmergency(string description, string level, string registrationTime, string secondary);

        string RegisterOrderEmergency(string description, string level, string registrationTime, string secondary);

        string RegisterFireServiceCenter(string name, int amountOfMaximumEmergencies);

        string RegisterMedicalServiceCenter(string name, int amountOfMaximumEmergencies);

        string RegisterPoliceServiceCenter(string name, int amountOfMaximumEmergencies);

        string ProcessEmergencies(string type);

        string EmergencyReport();
    }
}
