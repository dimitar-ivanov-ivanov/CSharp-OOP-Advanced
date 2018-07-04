namespace LambdaCore_Skeleton.Contracts
{
    public interface ICoreFactory
    {
        ICore Create(string name, string type, int durability);
    }
}
