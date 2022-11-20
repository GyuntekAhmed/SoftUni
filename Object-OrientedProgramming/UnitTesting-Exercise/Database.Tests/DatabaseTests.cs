namespace Database.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_DatabaseConstructorShouldAddLessThan16Elements(int[] elements)
        {
            // Arrange
            Database testData = new Database(elements);

            // Act
            int[] actualData = testData.Fetch();
            int[] expectedData = elements;

            int currentCount = testData.Count;
            int expectedCount = expectedData.Length;

            // Assert
            CollectionAssert.AreEqual
                (expectedData, actualData, "Constructor should initialize data field correctly.");
            Assert.AreEqual
                (expectedCount, currentCount, "Constructor set initial value for count field.");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void ConstructorMustAllowToChangeMaximumCount(int[] elements)
        {
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database testData = new Database(elements);
            },
            "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void CountMustReturnActualCount()
        {
            // Arrange
            int[] initializeData = new int[] { 1, 2, 3, 4, 5 };
            Database testData = new Database(initializeData);

            // Act
            int actualCount = testData.Count;
            int expectedCount = initializeData.Length;

            // Assert
            Assert.AreEqual
                (expectedCount, actualCount, "Count should return the count of the added elements.");
        }
        [Test]
        public void CountMustReturnZeroWhenNoElements()
        {
            // Arrange
            int actualCount = database.Count;
            int expectedCount = 0;

            // Assert
            Assert.AreEqual
                (expectedCount, actualCount, "Count should be zero when there are no elements in the Database.");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] elements)
        {
            // Act
            foreach (var element in elements)
            {
                database.Add(element);
            }

            int[] actualData = database.Fetch();
            int[] expectedData = elements;

            int actualCount = database.Count;
            int expectedCount = expectedData.Length;

            // Assert
            CollectionAssert.AreEqual
                (expectedData, actualData, "Add should added the elements to the field.");
            Assert.AreEqual
                (expectedCount, actualCount, "Add should change the elements count when adding.");
        }

        [Test]
        public void AddShouldThrowExcpetionWhenAddMoreThan16Elements()
        {
            // Act
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            // Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            },
            "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveShouldRemoveTheLastElementOnce(int[] startElements)
        {
            // Act
            foreach (var element in startElements)
            {
                database.Add(element);
            }

            database.Remove();
            List<int> list = new List<int>(startElements);
            list.RemoveAt(list.Count - 1);

            int[] actualData = database.Fetch();
            int[] expectedData = list.ToArray();

            int actualCount = database.Count;
            int expectedCount = expectedData.Length;

            // Assert
            CollectionAssert.AreEqual
                (expectedData, actualData, "Should remove the element in the data field.");
            Assert.AreEqual
                (expectedCount, actualCount, "Remove should decrement the count of the Database.");
        }
        [Test]
        public void RemoveShouldRemoveTheLastElementMoreThanOnce()
        {
            // Arrange
            List<int> intData = new List<int>() { 1, 2, 3, 4, 5 };
            // Act
            foreach (int element in intData)
            {
                database.Add(element);
            }

            for (int i = 0; i < intData.Count; i++)
            {
                database.Remove();
            }

            int[] actualData = database.Fetch();
            int[] expectedData = new int[] { };

            int actualCount = database.Count;
            int expectedCount = 0;

            CollectionAssert.AreEqual
                (expectedData, actualData, "Should remove the element in the data field.");
            Assert.AreEqual
                (expectedCount, actualCount, "Remove should decrement the count of the Database.");
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenThereAreNoElements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            },
            "The collection is empty!");
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnCopy(int[] initData)
        {
            // Act
            foreach (int element in initData)
            {
                database.Add(element);
            }

            int[] actualResult = database.Fetch();
            int[] expectedResult = initData;

            // Assert
            CollectionAssert.AreEqual
                (expectedResult, actualResult, "Fetch should return copy of the existing data.");
        }
    }
}