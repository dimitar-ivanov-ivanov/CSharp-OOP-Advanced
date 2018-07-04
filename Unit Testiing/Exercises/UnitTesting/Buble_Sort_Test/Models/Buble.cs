namespace Buble_Sort_Test.Models
{
    public class Buble
    {
        public void Sort(int[] numbers)
        {
            var swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if(numbers[i] > numbers[i + 1])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
}