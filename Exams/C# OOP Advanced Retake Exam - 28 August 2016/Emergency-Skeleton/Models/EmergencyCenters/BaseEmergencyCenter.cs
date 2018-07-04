namespace Emergency_Skeleton.Models.EmergencyCenters
{
    using Emergency_Skeleton.Contracts;

    public abstract class BaseEmergencyCenter : IEmergencyCenter
    {
        private string name;

        private int amountOfMaximumEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.amountOfMaximumEmergencies = amountOfMaximumEmergencies;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public bool isForRetirement()
        {
            return this.AmountOfMaximumEmergencies == 0;
        }
    }
}
