namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Enums;

    public class ParaCore : BaseCore
    {
        private const int DurabilityDivisor = 3;

        public ParaCore(CoreType type, int durability, string name) 
            : base(type, durability, name)
        {
            this.Durability /= DurabilityDivisor;
        }
    }
}
