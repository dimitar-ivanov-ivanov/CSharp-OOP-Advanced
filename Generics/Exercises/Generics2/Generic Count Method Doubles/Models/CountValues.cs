namespace Generic_Count_Method_Strings.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CountValues
    {
        public static int CountValuesGreaterThan<T>
            (IList<T> list, T value) where T : IComparable<T>
        {
            return list
                .Where(x => x.CompareTo(value) == 1)
                .Count();
        }
    }
}
