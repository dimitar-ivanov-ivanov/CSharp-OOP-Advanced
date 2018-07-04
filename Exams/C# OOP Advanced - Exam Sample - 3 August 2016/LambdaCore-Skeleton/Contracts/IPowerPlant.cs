namespace LambdaCore_Skeleton.Contracts
{
    public interface IPowerPlant
    {
        string CreateCore(string type, int durability);

        string RemoveCore(string name);

        string SelectCore(string name);

        string AttachFragment(string name, string type, int pressureAffection);

        string DetachFragment();

        string Status();
    }
}
