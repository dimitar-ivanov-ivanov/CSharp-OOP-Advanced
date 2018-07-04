namespace Strategy_Pattern.Models
{
    using Comparing_Objects.Contracts;
    using System.Collections.Generic;

    public class PersonLengthComparer : IComparer<IPerson>
    {
        public int Compare(IPerson x, IPerson y)
        {
            if (x.Name.Length != y.Name.Length)
            {
                return x.Name.Length.CompareTo(y.Name.Length);
            }

            var firstLetterX = x.Name.ToLower()[0];
            var firstLetterY = y.Name.ToLower()[0];

            return firstLetterX.CompareTo(firstLetterY);
        }
    }
}