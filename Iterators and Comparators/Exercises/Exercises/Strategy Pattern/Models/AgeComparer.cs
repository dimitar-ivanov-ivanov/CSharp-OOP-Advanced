namespace Strategy_Pattern.Models
{
    using Comparing_Objects.Contracts;
    using System.Collections.Generic;

    public class AgeComparer : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}