namespace BashSoftTesting
{
    using BashSoft.Contracts;
    using BashSoft.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestCtorInitialComparer()
        {
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>
                (() => this.names.Add(null));
        }

        [TestCase("Rosen", "Georgi", "Balkan")]
        [TestCase("Balkan", "Georgi", "Rosen")]
        public void TestAddUnsortedDataIsHeldSorted(params string[] arr)
        {
            this.names.AddAll(arr);
            var sortedNames = new string[arr.Length];
            var index = 0;

            foreach (var item in names)
            {
                sortedNames[index++] = item;
            }

            for (int i = 1; i < sortedNames.Length; i++)
            {
                Assert.IsTrue(sortedNames[i].CompareTo(sortedNames[i - 1]) == 1);
            }
        }

        [TestCase(17)]
        public void TestAddingMoreThanInitialCapacity(int inputCount)
        {
            var elements = GetElements(inputCount);
            this.names.AddAll(elements);

            Assert.AreEqual(names.Size, 17);
            Assert.IsTrue(names.Capacity != 16);
        }

        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var elements = new List<string>();
            elements.Add("Ivan");
            elements.Add("Pesho");

            this.names.AddAll(elements);

            Assert.AreEqual(names.Size, 2);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [TestCase(20)]
        [TestCase(10)]
        [TestCase(15)]
        public void TestAddAllKeepsSorted(int inputCount)
        {
            var elements = GetElements(inputCount);
            this.names.AddAll(elements);
            var sortedNames = new string[elements.Length];
            var index = 0;

            foreach (var item in names)
            {
                sortedNames[index++] = item;
            }

            for (int i = 1; i < sortedNames.Length; i++)
            {
                Assert.IsTrue(sortedNames[i].CompareTo(sortedNames[i - 1]) == 1);
            }
        }

        [TestCase("Test")]
        public void TestRemoveValidElementDecreasesSize(string element)
        {
            this.names.Add(element);
            this.names.Remove(element);

            Assert.AreEqual(this.names.Size, 0);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Nasko");

            this.names.Remove("Ivan");

            Assert.AreEqual(null, this.names.FirstOrDefault(x => x == "Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.AddAll(new string[] { "1", "2", "3" });

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            var arr = new string[] { "1", "2", "3" };
            this.names.AddAll(arr);

            var joined = this.names.JoinWith(" ");

            Assert.AreEqual(string.Join(" ", arr), joined);
        }

        private string[] GetElements(int inputCount)
        {
            var arr = new string[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                arr[i] = $"Test - {i}";
            }

            return arr;
        }
    }
}
