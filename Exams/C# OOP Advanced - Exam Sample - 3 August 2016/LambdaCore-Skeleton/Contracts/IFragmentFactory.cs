namespace LambdaCore_Skeleton.Contracts
{
    public interface IFragmentFactory
    {
        IFragment Create(string name, string type, int pressureAffection);
    }
}
