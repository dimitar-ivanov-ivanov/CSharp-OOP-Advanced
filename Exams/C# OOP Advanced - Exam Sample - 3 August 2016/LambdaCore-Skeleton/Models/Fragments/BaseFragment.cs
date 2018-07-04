namespace LambdaCore_Skeleton.Models.Fragments
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;
    using System;

    public abstract class BaseFragment : IFragment
    {
        private int pressureAffection;

        protected BaseFragment(string name, int pressureAffection, FragmentType type)
        {
            Name = name;
            PressureAffection = pressureAffection;
            Type = type;
        }

        public string Name { get; protected set; }

        public int PressureAffection
        {
            get { return this.pressureAffection; }
            protected set
            {
                this.pressureAffection = Math.Max(0,value);
            }
        }

        public FragmentType Type { get; }

        public abstract int Affect();
    }
}
