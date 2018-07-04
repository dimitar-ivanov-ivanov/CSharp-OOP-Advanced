public class Easy : Mission
{
    private const string EasyName = "Suppression of civil rebellion";
    private const double EasyEnduranceRequired = 20;
    private const double EasyWearLevelDecrement = 30;

    public Easy(double scoreToComplete)
        : base(EasyName, EasyEnduranceRequired, scoreToComplete, EasyWearLevelDecrement)
    {
    }
}
