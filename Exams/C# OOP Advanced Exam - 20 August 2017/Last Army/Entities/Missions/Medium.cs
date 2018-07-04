public class Medium : Mission
{
    private const string MediumName = "Capturing dangerous criminals";
    private const double MediumEnduranceRequired = 50;
    private const double MediumWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
       : base(MediumName, MediumEnduranceRequired, scoreToComplete, MediumWearLevelDecrement)
    {
    }
}
