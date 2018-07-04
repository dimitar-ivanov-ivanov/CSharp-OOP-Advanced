namespace LambdaCore_Skeleton.Contracts
{
    using LambdaCore_Skeleton.Enums;

    public interface ICore
    {
        string Name { get; }

        CoreType Type { get; }

        int Durability { get; }

        long Pressure { get; }

        int FragmentCount { get; }

        CoreStatus Status { get; }

        void AttachFragment(IFragment fragment);

        IFragment DetachFragment();
    }
}
