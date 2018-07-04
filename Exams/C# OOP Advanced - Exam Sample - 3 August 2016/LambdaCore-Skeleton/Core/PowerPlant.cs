namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PowerPlant : IPowerPlant
    {
        private IFragmentFactory fragmentFactory;
        private ICoreFactory coreFactory;

        private IList<ICore> cores;
        private ICore selectedCore;

        private int counter;
        private char nameToGive;

        public PowerPlant(IFragmentFactory fragmentFactory, ICoreFactory coreFactory)
        {
            this.fragmentFactory = fragmentFactory;
            this.coreFactory = coreFactory;
            this.cores = new List<ICore>();

            this.nameToGive = 'A';
            this.counter = 0;
        }

        public string CreateCore(string type, int durability)
        {
            if (durability < 0)
            {
                return Constants.FailedAddingCore;
            }

            var name = ((char)(nameToGive + counter)).ToString();
            counter++;

            try
            {
                var core = this.coreFactory.Create(name, type, durability);
                this.cores.Add(core);
            }
            catch (Exception)
            {
                return Constants.FailedAddingCore;
            }

            return string.Format(Constants.SuccessfullyAddedCore, name);
        }

        public string AttachFragment(string name, string type, int pressureAffection)
        {
            if (pressureAffection < 0)
            {
                return string.Format(Constants.FailedToAttach, name);
            }

            try
            {
                var fragment = this.fragmentFactory.Create(name, type, pressureAffection);
                selectedCore.AttachFragment(fragment);
            }
            catch (Exception)
            {
                return string.Format(Constants.FailedToAttach, name);
            }

            return string.Format(Constants.AttachedFragment, name, selectedCore.Name);
        }

        public string DetachFragment()
        {
            try
            {
                var fragment = selectedCore.DetachFragment();
                return string.Format(Constants.DetachedSuccessful, fragment.Name, selectedCore.Name);
            }
            catch (Exception)
            {
                return string.Format(Constants.DetachedUnsuccessful);
            }
        }

        public string RemoveCore(string name)
        {
            var core = this.cores.FirstOrDefault(x => x.Name == name);
            if (core != null)
            {
                this.cores.Remove(core);
                if (this.selectedCore.Name == core.Name)
                {
                    this.selectedCore = null;
                }
                return string.Format(Constants.RemovingSuccessfullyCore, name);
            }

            return string.Format(Constants.RemovingFailedCore, name);
        }

        public string SelectCore(string name)
        {
            var core = this.cores.FirstOrDefault(x => x.Name == name);
            if (core == null)
            {
                return string.Format(Constants.FailedToSelectCore, name);
            }

            this.selectedCore = core;
            return string.Format(Constants.CurrentlySelectedCore, name);
        }

        public string Status()
        {
            var output = new StringBuilder();

            var totalDurability = this.cores.Sum(x => x.Durability);
            var totalFragments = this.cores.Sum(x => x.FragmentCount);

            output.AppendLine("Lambda Core Power Plant Status: ");
            output.AppendLine($"Total Durability: {totalDurability}");
            output.AppendLine($"Total Cores: {this.cores.Count}");
            output.AppendLine($"Total Fragments: {totalFragments}");

            foreach (var core in this.cores)
            {
                output.AppendLine(core.ToString());
            }

            output = output.Remove(output.Length - 2, 2);
            return output.ToString();
        }
    }
}
