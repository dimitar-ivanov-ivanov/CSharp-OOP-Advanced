namespace LambdaCore_Skeleton.Models.Cores
{
    using LambdaCore_Skeleton.Collection;
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;

    public abstract class BaseCore : ICore
    {
        private int durability;

        private LStack<IFragment> stack;
        private int maxDurability;

        protected BaseCore(CoreType type, int durability, string name)
        {
            Type = type;
            maxDurability = durability;
            Durability = durability;
            Name = name;
            this.stack = new LStack<IFragment>();
        }

        public CoreType Type { get; }

        public int Durability
        {
            get
            {
                var currentDurability = (int)((long)durability - this.Pressure);

                return currentDurability > 0 ? currentDurability : 0;
            }
            protected set
            {
                if(value < 0)
                {
                    value = 0;
                }

                this.durability = value;
            }
        }

        public string Name { get; }

        public long Pressure
        {
            get
            {
                long currentPressure = 0;

                foreach (var item in this.stack)
                {
                    currentPressure += item.Affect();
                }

                return currentPressure > 0 ? currentPressure : 0;
            }
        }

        public int FragmentCount
        {
            get { return this.stack.Count(); }
        }

        public CoreStatus Status
        {
            get
            {
                return this.Pressure > 0 ? CoreStatus.CRITICAL : CoreStatus.NORMAL;
            }
        }

        public void AttachFragment(IFragment fragment)
        {
            this.stack.Push(fragment);
        }

        public IFragment DetachFragment()
        {
            var toRemove = this.stack.Pop();
            return toRemove;
        }

        public override string ToString()
        {
            return $"Core {this.Name}:\n" +
                   $"####Durability: {this.Durability}\n" +
                   $"####Status: {this.Status}";
        }
    }
}
