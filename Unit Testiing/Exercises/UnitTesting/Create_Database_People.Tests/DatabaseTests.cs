namespace Create_Database_People.Tests
{
    using Create_Database_People.Models;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private const int MinimumCapacity = 0;
        private const int MaximumCapacity = 16;
        private Person element = new Person("Pesho", 100);

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void CheckCapacityIs16(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

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
            var sut = new Database(elements);

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
                 (() => new Database(elements));

            Assert.AreEqual(ex.Message, "Data length must not exceed capacity."
                , "Database can be initialized with data with length bigger than capacity.");
        }

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void DatabaseDoesntThrowExceptionWhenInputElementsLengthIsBelowCapacity(int inputCount)
        {
            var elements = GetElements(inputCount);

            Assert.DoesNotThrow(() => new Database(elements),
                "Exception is thrown when correctly intializing database.");

        }

        [Test]
        public void DatabaseThrowsExceptionWhenGivenNull()
        {
            var ex = Assert.Throws<NullReferenceException>(() => new Database(null));

            Assert.AreEqual(ex.Message, "Object reference not set to an instance of an object.",
                "Database can take null as input collection.");
        }

        [TestCase(MinimumCapacity)]
        [TestCase(MaximumCapacity)]
        [TestCase(MinimumCapacity + 5)]
        [TestCase(MaximumCapacity / 2)]
        public void DatabaseCountCorrectAfterInitialization(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            Assert.AreEqual(sut.Count, inputCount,
                "Database count is incorrect after initialization.");
        }

        [TestCase(MaximumCapacity)]
        public void DatabaseThrowsExceptionWhenAddingToFullDatabase(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var ex = Assert.Throws<InvalidOperationException>(() => sut.Add(element));

            Assert.AreEqual(ex.Message, "Adding an element exceeds capacity.",
                "Database can add items to database.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseDoesntThrowExceptionWhenAddingToNotFullDatabase(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            Assert.DoesNotThrow(() => sut.Add(element),
                "Database throws exception when adding correctly.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseAddingIncreasesCount(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            sut.Add(element);

            Assert.AreEqual(inputCount + 1, sut.Count,
                "Count doesnt change after adding.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseAddCorrectItem(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            sut.Add(element);

            Assert.AreEqual(sut.Last, element,
                "Database doesnt add correct item.");
        }

        [TestCase(MinimumCapacity)]
        public void DatabaseThrowsExceptionWhenRemovingFromEmptyDatabase(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

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
            var sut = new Database(elements);

            Assert.DoesNotThrow(() => sut.Remove(),
                "Database throws exception when correctly removing.");
        }

        [TestCase(MaximumCapacity - 1)]
        [TestCase(MaximumCapacity - 5)]
        [TestCase(MaximumCapacity - 10)]
        public void DatabaseRemoveDecreasesCount(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

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
            var sut = new Database(elements);

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
            var sut = new Database(elements);

            for (int i = 0; i < inputCount; i++)
            {
                Assert.AreEqual(elements[i], sut.Data[i],
                    "Fetching doesnt return the correct items.");
            }
        }

        [TestCase(MaximumCapacity)]
        [TestCase(MaximumCapacity / 2)]
        [TestCase(MaximumCapacity - 5)]
        public void DatabaseFetchHasCorrectCount(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            Assert.AreEqual(elements.Length, sut.Count,
                "Fetched array has incorrect count.");
        }

        [TestCase(MaximumCapacity)]
        [TestCase(MaximumCapacity / 2)]
        [TestCase(MaximumCapacity - 5)]
        public void DatabaseThrowsExceptionWhenFetchingPersonWithNameNull(int inputCount)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var ex = Assert.Throws<ArgumentException>(() => sut.FetchByUsername(null));

            Assert.AreEqual(ex.Message, "Name cannot be null.",
                "Database is able to find a person with name null.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseDoenstThrowExceptionWhenFetchingPersonWithName(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var elementString = ((char)elementNumber).ToString();

            Assert.DoesNotThrow(() => sut.FetchByUsername(elementString),
                "Database throws exception on valid name search.");

        }

        [TestCase(MaximumCapacity, 100)]
        [TestCase(MaximumCapacity / 2, 200)]
        [TestCase(MaximumCapacity - 5, 300)]
        public void DatabaseThrowsExceptionWhenFetchNonExistingPersonByName(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var elementString = ((char)elementNumber).ToString();

            var ex = Assert.Throws<InvalidOperationException>(() => sut.FetchByUsername(elementString));

            Assert.AreEqual("Person with name doesn't exist.", ex.Message,
                "Database finds person that doenst exist in the database.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseDoesntThrowExceptionWhenFetchingPersonByName(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var elementString = ((char)elementNumber).ToString();

            Assert.DoesNotThrow(() => sut.FetchByUsername(elementString),
                "Database throws exception on searching valid item.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseFetchCorrectPersonByName(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var elementString = ((char)elementNumber).ToString();

            var person = sut.FetchByUsername(elementString);

            Assert.AreEqual(person, sut.Data[elementNumber],
                "Database cannot find item that's in database.");
        }

        [TestCase(MaximumCapacity, -1)]
        [TestCase(MaximumCapacity / 2, -2)]
        [TestCase(MaximumCapacity - 5, -3)]
        public void DatabaseThrowsExceptionWhenFetchingNegativeId(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var ex = Assert.Throws<ArgumentException>(() => sut.FetchById(elementNumber));

            Assert.AreEqual(ex.Message, "Id cannot be negative.",
                "Database doesnt throw valid exception on looking up person with negative id.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseDoesntThrowExceptionWhenFetchingCorrectId(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            Assert.DoesNotThrow(() => sut.FetchById(elementNumber),
                "Database shouldn't throw exception when searching correct item.");
        }

        [TestCase(MaximumCapacity, 100)]
        [TestCase(MaximumCapacity / 2, 200)]
        [TestCase(MaximumCapacity - 5, 300)]
        public void DatabaseThrowsExceptionWhenFetchingNonExistingPersonById(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var ex = Assert.Throws<InvalidOperationException>(() => sut.FetchById(elementNumber));

            Assert.AreEqual(ex.Message, "User with id doesn't exists.",
                "Database should throw exception when searching invalid person.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseDoesntThrowExceptionWhenFetchingPersonById(int inputCount, int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            Assert.DoesNotThrow(() => sut.FetchById(elementNumber),
                "Database shouldn't throw exception when searching correct item.");
        }

        [TestCase(MaximumCapacity, 0)]
        [TestCase(MaximumCapacity / 2, 1)]
        [TestCase(MaximumCapacity - 5, 2)]
        public void DatabaseFetchCorrectPersonById(int inputCount,int elementNumber)
        {
            var elements = GetElements(inputCount);
            var sut = new Database(elements);

            var person = sut.FetchById(elementNumber);

            Assert.AreEqual(person, sut.Data[elementNumber],
                "Database cannot find item that's in database.");
        }

        public Person[] GetElements(int capacity)
        {
            var arr = new Person[capacity];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Person(((char)i).ToString(), i);
            }

            return arr;
        }
    }
}
