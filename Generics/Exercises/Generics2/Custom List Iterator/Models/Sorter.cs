namespace Custom_List_Iterator.Models
{
    using Custom_List_Iterator.Contracts;
    using System;
    using System.Linq;

    public class Sorter
    {
        public static ICustomList<T> Sort<T>(ICustomList<T> customList)
            where T : IComparable<T>
        {
            var data = customList.Data
                .OrderBy(x => x)
                .ToList();

            return new CustomList<T>(data);
        }
    }
}
