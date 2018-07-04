namespace Iterator_Test.Tests
{
    using Iterator_Test.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class IteratorTests
    {
        private const int DataLength = 20;

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratoDataIsCorrect(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            for (int i = 0; i < elements.Length; i++)
            {
                Assert.AreEqual(elements[i], sut[i],
                    "Incorrect elements are passed.");
            }
        }

        [Test]
        public void IteratorThrowsExceptionWhenInitializingWithNull()
        {
            var ex = Assert.Throws<ArgumentNullException>
                (() => new ListIterator(null));

            Assert.AreEqual(ex.ParamName, "Data cannot be null.",
                "List can be initialized with null data.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorDoesntThrowExceptionWhenInitializingWithValidItems(int inputCount)
        {
            var elements = GetElements(inputCount);

            Assert.DoesNotThrow(() => new ListIterator(elements),
                "List cannot be initalized without throwing exceptions.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorCountIsCorrectAfterInitialization(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            Assert.AreEqual(inputCount, sut.Count,
                "Count is incorrect after initialization.");

        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorHasNext(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            Assert.IsTrue(sut.HasNext(), "List doesnt have next even though index has not been moved.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorDoesntHaveNext(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            for (int i = 0; i < inputCount; i++)
            {
                sut.MoveNext();
            }

            Assert.IsFalse(sut.HasNext(), "List can move even though it's at the end of the data.",
                "Iterator shouldn't have be able to move next.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorMoveNextWorks(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            Assert.IsTrue(sut.MoveNext(), "List cannot move next when index is zero.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorMovesNextDoesntWork(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            for (int i = 0; i < inputCount; i++)
            {
                sut.MoveNext();
            }

            Assert.IsFalse(sut.MoveNext(), "List can move even though it's at the end of the data.",
                           "Iterator shouldn't have be able to move next.");
        }

        [Test]
        public void IteratorThowsExceptionWhenPrintingEmptyDatabase()
        {
            var elements = GetElements(0);
            var sut = new ListIterator(elements);

            var ex = Assert.Throws<InvalidOperationException>(() => sut.Print());

            Assert.AreEqual(ex.Message, "Invalid Operation!",
                "List is able to print items with no items existing.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorPrintsCorrectElement(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            var print = sut.Print();

            Assert.AreEqual(print, elements[0],
                "List Prints invalid item.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength - 5)]
        public void IteratorResetGetsIndexToZero(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new ListIterator(elements);

            for (int i = 0; i < inputCount; i++)
            {
                sut.MoveNext();
            }

            sut.Reset();

            Assert.AreEqual(sut.Index, 0,
                "List reset doesnt get index to zero");
        }

        public string[] GetElements(int inputCount)
        {
            var arr = new string[inputCount];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i.ToString();
            }

            return arr;
        }
    }
}
