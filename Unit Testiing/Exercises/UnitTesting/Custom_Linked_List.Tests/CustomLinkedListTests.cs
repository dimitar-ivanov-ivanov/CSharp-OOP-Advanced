namespace Custom_Linked_List.Tests
{
    using Custom_Linked_List.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CustomLinkedListTests
    {
        private CustomLinkedList<string> customLinkedList;

        private const string First = "First";
        private const string Second = "Second";

        private const int DataLength = 10;

        [SetUp]
        public void InitializeList()
        {
            this.customLinkedList = new CustomLinkedList<string>();
        }

        [Test]
        public void ListThrowsExceptionWhenAddingNewNodeWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.customLinkedList.Add(null));

            Assert.AreEqual(ex.ParamName, "Node value cannot be null.",
                "List can add a null value.");
        }

        [Test]
        public void ListDoesntThrowExceptionWhenAddingNewNodeWithCorrectValue()
        {
            Assert.DoesNotThrow(() => this.customLinkedList.Add("Test"),
                "List throws exception when adding correctly");
        }

        [Test]
        public void ListAddingIncreasesCount()
        {
            var currentCount = this.customLinkedList.Count;
            this.customLinkedList.Add(First);

            Assert.AreEqual(currentCount + 1, this.customLinkedList.Count,
                "List adding doesnt increase count.");
        }

        [Test]
        public void ListAddingItemBecomesFirst()
        {
            this.customLinkedList.Add(First);

            Assert.AreEqual(First, this.customLinkedList.First.Value,
                "First added element doesnt become the first.");
        }

        [Test]
        public void ListSecondAddingItemBecomesLast()
        {
            this.customLinkedList.Add(First);
            this.customLinkedList.Add(Second);

            Assert.AreEqual(Second, this.customLinkedList.Last.Value,
                "Last item is not added properly.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength * 2)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength + 5)]
        public void ListAddingCollectionChecksFirst(int inputCount)
        {
            var elements = GetElements(inputCount);

            for (int i = 0; i < inputCount; i++)
            {
                this.customLinkedList.Add(elements[i]);
            }

            Assert.AreEqual(this.customLinkedList.First, elements[0],
                "First element is incorectly added when adding a collection.");
        }

        [TestCase(DataLength)]
        [TestCase(DataLength * 2)]
        [TestCase(DataLength / 2)]
        [TestCase(DataLength + 5)]
        public void ListAddingCollectionChecksLast(int inputCount)
        {
            var elements = GetElements(inputCount);

            for (int i = 0; i < inputCount; i++)
            {
                this.customLinkedList.Add(elements[i]);
            }

            Assert.AreEqual(this.customLinkedList.Last, elements[inputCount - 1],
                "Last element is incorectly added when adding a collection.");
        }

        [Test]
        public void ListThrowsExceptionWhenContainIsCalledWithNull()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.customLinkedList.Contains(null));

            Assert.AreEqual(ex.ParamName, "List cannot contain node value that's null.",
                "Contains method can find a null element.");
        }

        [Test]
        public void ListDoesntThrowExceptionWhenContainIsCalledWithNonNull()
        {
            Assert.DoesNotThrow(() => this.customLinkedList.Contains(First),
                "List throws exception when conducting a normal Contains method.");
        }

        [TestCase(First)]
        [TestCase(Second)]
        public void ListContainsElement(string val)
        {
            this.customLinkedList.Add(val);

            Assert.IsTrue(this.customLinkedList.Contains(val),
                "List cannot find existing element.");
        }

        [Test]
        public void ListDoesntContainElement()
        {
            Assert.IsFalse(this.customLinkedList.Contains(First),
                "List finds a non existing item.");
        }

        [Test]
        public void ListThrowsExceptionWhenIndexOfIsCalledWithNullValue()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.customLinkedList.IndexOf(null));

            Assert.AreEqual(ex.ParamName, "List cannot contain node value that's null.",
                "Index of can find the index of a null item.");
        }

        [Test]
        public void ListDoesntThrowsExceptionWhenIndexOfIsCalledWithCorrectValue()
        {
            this.customLinkedList.Add(First);

            Assert.DoesNotThrow(() => this.customLinkedList.IndexOf(First),
                "List throws exception when searching valid items.");
        }

        [Test]
        public void ListIndexOfGivesCorrectIndex()
        {
            this.customLinkedList.Add(First);

            Assert.AreEqual(this.customLinkedList.IndexOf(First), 0,
                "Item is not added at the beginning.");
        }

        [Test]
        public void ListIndexOfGivesMinusOne()
        {
            Assert.AreEqual(this.customLinkedList.IndexOf(First), -1,
                "List finds a nonexistring item.");
        }

        [Test]
        public void ListThrowsExceptionWhenRemovingNullItem()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => this.customLinkedList.Remove(null));

            Assert.AreEqual(ex.ParamName, "Cannot remove a null item.",
                "List has to throw exception when removing a null element.");
        }

        [Test]
        public void ListDoesntThrowExceptionWhenRemovingValidItem()
        {
            this.customLinkedList.Add(First);

            Assert.DoesNotThrow(() => this.customLinkedList.Remove(First),
                "List throws exception when normally removing an element.");
        }

        [Test]
        public void ListRemoveGivesIndexOfDeletedItem()
        {
            this.customLinkedList.Add(First);

            var index = this.customLinkedList.Remove(First);

            Assert.AreEqual(index, 0,
                "List doesnt give valid index of removed item.");
        }

        [Test]
        public void ListRemoveReturnsNegativeIndexWhenCannotFindItem()
        {
            var index = this.customLinkedList.Remove(First);

            Assert.AreEqual(index, -1,
                "List Removes non existing item.");
        }

        [Test]
        public void ListRemoveDecreasesCount()
        {
            this.customLinkedList.Add(First);

            var count = customLinkedList.Count;

            this.customLinkedList.Remove(First);

            Assert.AreEqual(this.customLinkedList.Count, count - 1,
                "Removing an item doesnt affect count.");
        }

        [Test]
        public void ListRemoveDeletesItem()
        {
            this.customLinkedList.Add(First);

            this.customLinkedList.Remove(First);

            Assert.IsFalse(this.customLinkedList.Contains(First),
                "List cannot remove item.");
        }

        [TestCase(-1)]
        [TestCase(2)]
        public void ListRemoveAtThrowsExceptionWhenIndexIsNegativeOrExceedsCount(int index)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => this.customLinkedList.RemoveAt(index));

            Assert.AreEqual(ex.ParamName, $"Invalid index: {index}",
                "List doesnt throw exception when index of item is negative or exceeds count.");
        }

        [TestCase(1)]
        [TestCase(0)]
        public void ListRemoveAtDoesntThrowExceptionWhenIndexIsNotNegativeAndDoesntExceedsCount(int index)
        {
            this.customLinkedList.Add(First);
            this.customLinkedList.Add(Second);

            Assert.DoesNotThrow(() => this.customLinkedList.RemoveAt(index),
                "List throws exception when casually removing.");
        }

        [Test]
        public void ListRemoveAtDecreasesCount()
        {
            this.customLinkedList.Add(First);
            this.customLinkedList.Add(Second);
            var count = this.customLinkedList.Count;

            this.customLinkedList.RemoveAt(0);

            Assert.AreEqual(count - 1, this.customLinkedList.Count,
                  "List remove doesn't change count.");
        }

        [Test]
        public void ListRemoveAtDeletesItem()
        {
            this.customLinkedList.Add(First);

            this.customLinkedList.RemoveAt(0);

            Assert.IsFalse(this.customLinkedList.Contains(First), 
                "List cannot remove item correctly.");
        }

        public string[] GetElements(int inputCount)
        {
            var arr = new string[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                arr[i] = i.ToString();
            }

            return arr;
        }
    }
}
