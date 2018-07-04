public class Hard : Mission
{
    private const string HardName = "Disposal of terrorists";
    private const double HardEnduranceRequired = 80;
    private const double HardWearLevelDecrement = 70;


    public Hard(double scoreToComplete)
        : base(HardName, HardEnduranceRequired, scoreToComplete, HardWearLevelDecrement)
    {
    }
}

