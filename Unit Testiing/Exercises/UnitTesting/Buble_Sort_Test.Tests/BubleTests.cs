namespace Buble_Sort_Test.Tests
{
    using Buble_Sort_Test.Models;
    using NUnit.Framework;

    [TestFixture]
    public class BubleTests
    {
        [TestCase(0, 1, 2, 3, 4, 5)]
        [TestCase(5, 4, 3, 2, 1, 0)]
        [TestCase(0, -1, 2, -3, 4, -5)]
        [TestCase(1, 1, 1, 1, 1, 1)]
        public void BubleSortsArrayCorrectly(params int[] arr)
        {
            var sut = new Buble();
            sut.Sort(arr);

            for (int i = 1; i < arr.Length; i++)
            {
                Assert.That(arr[i] >= arr[i - 1],
                    "Items aren't sorted.");
            }
        }
    }
}
