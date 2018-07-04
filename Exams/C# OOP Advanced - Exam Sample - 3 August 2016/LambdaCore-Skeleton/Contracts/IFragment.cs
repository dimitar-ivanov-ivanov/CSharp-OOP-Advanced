namespace LambdaCore_Skeleton.Contracts
{
    using LambdaCore_Skeleton.Enums;

    public interface IFragment
    {
        FragmentType Type { get; }

        string Name { get; }

        int PressureAffection { get; }

        int Affect();
    }
}
