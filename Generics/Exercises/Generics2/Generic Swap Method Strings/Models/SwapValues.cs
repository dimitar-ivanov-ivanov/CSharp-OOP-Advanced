namespace Generic_Swap_Method_Strings.Models
{
    using System.Collections.Generic;

    public static class SwapValues
    {
        public static void Swap<T>(IList<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
