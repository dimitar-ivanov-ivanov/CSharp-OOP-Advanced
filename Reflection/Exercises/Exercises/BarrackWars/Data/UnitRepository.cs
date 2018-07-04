namespace BarrackWars.Data
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class UnitRepository : IRepository
    {
        private IDictionary<string, int> amountOfUnits;

        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                var statBuilder = new StringBuilder();
                foreach (var entry in amountOfUnits)
                {
                    var formatedEntry =  string.Format("{0} -> {1}", entry.Key, entry.Value);
                    statBuilder.AppendLine(formatedEntry);
                }

                return statBuilder.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            var unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (!amountOfUnits.ContainsKey(unitType) ||
                amountOfUnits[unitType] == 0)
            {
                throw new ArgumentException("No such units in repository.");
            }

            this.amountOfUnits[unitType]--;
        }
    }
}
