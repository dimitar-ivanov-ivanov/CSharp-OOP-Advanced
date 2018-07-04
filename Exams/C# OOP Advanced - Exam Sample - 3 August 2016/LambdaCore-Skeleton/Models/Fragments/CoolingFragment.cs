namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Enums;

    public class CoolingFragment : BaseFragment
    {
        private const int PressureMultiplier = 3;

        public CoolingFragment(string name, int pressureAffection, FragmentType type) 
            : base(name, pressureAffection, type)
        {
            this.PressureAffection *= PressureMultiplier;
        }

        public override int Affect()
        {
            return -this.PressureAffection;
        }
    }
}
