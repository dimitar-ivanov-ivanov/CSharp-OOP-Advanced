namespace Create_Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int MinimumCapacity = 0;
        private const int MaximumCapacity = 16;
        private const int Element = 0;

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void CheckCapacityIs16(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            Assert.AreEqual(sut.Capacity, MaximumCapacity,
                "Capacity isn't correct.");
        }

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void InitializeCorrectElements(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            for (int i = 0; i < elements.Length; i++)
            {
                Assert.AreEqual(elements[i], sut.Data[i],
                    "Correct items haven't been pased.");
            }
        }

        [TestCase(MaximumCapacity + 1)]
        public void DatabaseThrowsExceptionWhenInputElementsLengthCapacity(int inputCount)
        {
            var elements = GetElements(inputCount);
            var ex = Assert.Throws<InvalidOperationException>
                 (() => new Models.Database(elements));

            Assert.AreEqual(ex.Message, "Data length must not exceed capacity."
                , "Models.Database can be initialized with data with length bigger than capacity.");
        }

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void DatabaseDoesntThrowExceptionWhenInputElementsLengthIsBelowCapacity(int inputCount)
        {
            var elements = GetElements(inputCount);

            Assert.DoesNotThrow(() => new Models.Database(elements),
                "Exception is thrown when correctly intializing database.");

        }

        [Test]
        public void DatabaseThrowsExceptionWhenGivenNull()
        {
            var ex = Assert.Throws<NullReferenceException>(() => new Models.Database(null));

            Assert.AreEqual(ex.Message, "Object reference not set to an instance of an object.",
                "Models.Database can take null as input collection.");
        }

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void DatabaseCountCorrectAfterInitialization(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            Assert.AreEqual(sut.Count, inputCount,
                "Models.Database count is incorrect after initialization.");
        }

        [TestCase(MaximumCapacity, Element)]
        public void DatabaseThrowsExceptionWhenAddingToFullDatabase(int inputCount, int element)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            var ex = Assert.Throws<InvalidOperationException>(() => sut.Add(element));

            Assert.AreEqual(ex.Message, "Adding an element exceeds capacity.",
                "Models.Database can add items to database.");
        }

        [TestCase(MaximumCapacity - 1, Element)]
        [TestCase(MaximumCapacity - 5, Element)]
        [TestCase(MaximumCapacity - 10, Element)]
        public void DatabaseDoesntThrowExceptionWhenAddingToNotFullDatabase(int inputCount, int element)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            Assert.DoesNotThrow(() => sut.Add(element),
                "Models.Database throws exception when adding correctly.");
        }

        [TestCase(MaximumCapacity - 1, Element)]
        [TestCase(MaximumCapacity - 5, Element)]
        [TestCase(MaximumCapacity - 10, Element)]
        public void DatabaseAddingIncreasesCount(int inputCount, int element)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            sut.Add(element);

            Assert.AreEqual(inputCount + 1, sut.Count,
                "Count doesnt change after adding.");
        }

        [TestCase(MaximumCapacity - 1, Element)]
        [TestCase(MaximumCapacity - 5, Element)]
        [TestCase(MaximumCapacity - 10, Element)]
        public void DatabaseAddCorrectItem(int inputCount, int element)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            sut.Add(element);

            Assert.AreEqual(sut.Last, element,
                "Models.Database doesnt add correct item.");
        }

        [TestCase(MinimumCapacity)]
        public void DatabaseThrowsExceptionWhenRemovingFromEmptyDatabase(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            var ex = Assert.Throws<InvalidOperationException>(() => sut.Remove());

            Assert.AreEqual(ex.Message, "Removing from empty database is impossible.",
                "Removing from empty database is possible.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseDoesntThrowExceptionWhenRemovingFromNonEmptyDatabase(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            Assert.DoesNotThrow(() => sut.Remove(),
                "Models.Database throws exception when correctly removing.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseRemoveDecreasesCount(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            sut.Remove();

            Assert.AreEqual(sut.Count, inputCount - 1,
                "Count is unchanged after removing.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseRemoveCorrectItem(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            var last = sut.Remove();

            Assert.AreEqual(last, elements[inputCount - 1],
                "Removed element isn't the last one.");
        }

        [TestCase(MaximumCapacity)]
        [TestCase(MaximumCapacity / 2)]
        [TestCase(MaximumCapacity - 5)]
        public void DatabaseFetchReturnCorrectItems(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            for (int i = 0; i < inputCount; i++)
            {
                Assert.AreEqual(elements[i], sut.Data[i],
                    "Fetching doesnt return the correct items.");
            }
        }

        [TestCase(MaximumCapacity)]
        [TestCase(MaximumCapacity /2)]
        [TestCase(MaximumCapacity - 5)]
        public void DatabaseFetchHasCorrectCount(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Models.Database(elements);

            Assert.AreEqual(elements.Length, sut.Count,
                "Fetched array has incorrect count.");
        }

        public int[] GetElements(int capacity)
        {
            var arr = new int[capacity];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            return arr;
        }
    }
}
