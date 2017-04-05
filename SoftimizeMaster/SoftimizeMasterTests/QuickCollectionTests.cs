using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftimizeMasterTests.Mocks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SoftimizeMaster.Tests
{
    [TestClass()]
    public abstract class QuickCollectionTests
    {
        /// <summary>
        /// Get instance of the concrete type.
        /// </summary>
        /// <typeparam name="T">Specifies the element type of the collection.</typeparam>
        /// <param name="comparer">Specify how elements will be compared.</param>
        /// <returns></returns>
        protected abstract QuickCollection<T> GetInstance<T>(IComparer<T> comparer);

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickCollectionTest_GetInstance_ComparerInvalid_Null()
        {
            // Arrange - Act
            var collection = GetInstance<int>(null);

            // Assert - throws an exception
        }

        [TestMethod()]
        public void AddTest_SingleValue_Valid()
        {
            AddTest_SingleValue_Valid_Helper<int>(5, Comparer<int>.Default);
            AddTest_SingleValue_Valid_Helper<string>("Test", Comparer<string>.Default);

            Person person = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };
            AddTest_SingleValue_Valid_Helper<Person>(person, PersonIdComparer.Instance);
        }

        private void AddTest_SingleValue_Valid_Helper<T>(T element, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            var expected = 1;

            // Act
            collection.Add(element);

            var actual = collection.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest_SingleValue_Invalid()
        {
            AddTest_SingleValue_Invalid_Helper<string>(null, Comparer<string>.Default);
            AddTest_SingleValue_Invalid_Helper<Person>(null, PersonIdComparer.Instance);
        }

        private void AddTest_SingleValue_Invalid_Helper<T>(T element, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            // Act
            collection.Add(element);

            // Assert - throws an exception 
        }

        [TestMethod()]
        public void AddTest_MultipleValues_Valid()
        {
            int[] intArr = { 1, 5, 8, 4, 3, 8, 345, 7, 3, 2, 8, 8, 554, 6 };
            AddTest_MultipleValues_Valid_Helper<int>(intArr, Comparer<int>.Default);

            string[] stringArr = { "some", "values", "to", "test" };
            AddTest_MultipleValues_Valid_Helper<string>(stringArr, Comparer<string>.Default);

            Person[] people =
            {
                new Person() { Id = 1, FirstName = "John", LastName = "Smith"},
                new Person() { Id = 2, FirstName = "Derek", LastName = "Due"},
                new Person() { Id = 3, FirstName = "Ben", LastName = "Cohen"}
            };
            AddTest_MultipleValues_Valid_Helper<Person>(people, PersonIdComparer.Instance);
        }

        private void AddTest_MultipleValues_Valid_Helper<T>(T[] elements, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            var expected = elements.Length;

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Add(elements[i]);
            }

            var actual = collection.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest_MultipleValues_Invalid()
        {
            string[] stringArr = { "some", null, "to", "test" };
            AddTest_MultipleValues_Invalid_Helper<string>(stringArr, Comparer<string>.Default);

            Person person = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };
            Person[] people =
            {
                new Person() { Id = 1, FirstName = "John", LastName = "Smith"},
                new Person() { Id = 2, FirstName = "Derek", LastName = "Due"},
                new Person() { Id = 3, FirstName = "Ben", LastName = "Cohen"},
                null
            };
            AddTest_MultipleValues_Invalid_Helper<Person>(people, PersonIdComparer.Instance);
        }

        private void AddTest_MultipleValues_Invalid_Helper<T>(T[] elements, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            // Act
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Add(elements[i]);
            }

            // Assert - throws an exception 
        }

        [TestMethod()]
        public void RemoveTest_SingleValue_Valid()
        {
            RemoveTest_SingleValue_Valid_Helper<int>(5, Comparer<int>.Default);
            RemoveTest_SingleValue_Valid_Helper<string>("Test", Comparer<string>.Default);

            Person person = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };
            RemoveTest_SingleValue_Valid_Helper<Person>(person, PersonIdComparer.Instance);
        }

        private void RemoveTest_SingleValue_Valid_Helper<T>(T element, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            var expected = element;

            // Act
            collection.Add(element);

            var actual = collection.Remove();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(collection.Count, 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveTest_EmptyCollection_Invalid()
        {
            RemoveTest_EmptyCollection_Invalid_Helper<int>(Comparer<int>.Default);
            RemoveTest_EmptyCollection_Invalid_Helper<string>(Comparer<string>.Default);
            RemoveTest_EmptyCollection_Invalid_Helper<Person>(PersonIdComparer.Instance);
        }

        private void RemoveTest_EmptyCollection_Invalid_Helper<T>(IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            // Act
            collection.Remove();

            var actual = collection.Remove();

            // Assert - throw an exception
        }

        [TestMethod()]
        public void RemoveTest_MultipleValues_Valid()
        {
            int[] intArr = { 1, 5, 8, 4, 3, 8, 345, 7, 3, 2, 8, 8, 554, 6 };
            RemoveTest_MultipleValues_Valid_Helper<int>(intArr, Comparer<int>.Default);

            string[] stringArr = { "some", "values", "to", "test" };
            RemoveTest_MultipleValues_Valid_Helper<string>(stringArr, Comparer<string>.Default);

            Person[] people =
            {
                new Person() { Id = 1, FirstName = "John", LastName = "Smith"},
                new Person() { Id = 2, FirstName = "Derek", LastName = "Due"},
                new Person() { Id = 3, FirstName = "Ben", LastName = "Cohen"}
            };
            RemoveTest_MultipleValues_Valid_Helper<Person>(people, PersonIdComparer.Instance);
        }

        private void RemoveTest_MultipleValues_Valid_Helper<T>(T[] elements, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Add(elements[i]);
            }

            Array.Sort(elements, comparer);

            var expected = elements.Last();

            // Act
            var actual = collection.Remove();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveTest_MultipleRandomValues_Valid()
        {
            // Arrange
            var comparer = Comparer<int>.Default;
            var collection = GetInstance<int>(comparer);
            var random = new Random();
            var randomList = new List<int>();
            var size = 10000;
            var maxRandValue = 50000;

            for (int i = 0; i < size; i++)
            {
                var randInt = random.Next(maxRandValue);
                randomList.Add(randInt);
                collection.Add(randInt);
            }

            // Act
            randomList.Sort(comparer);

            // Assert
            for (int i = randomList.Count - 1; i >= 0; i--)
            {
                var actual = collection.Remove();
                var expected = randomList[i];
                Assert.AreEqual(actual, expected);
            }
        }

        [TestMethod()]
        public void PublishTest_OnAdd()
        {
            PublishTest_OnAdd_Helper<int>(5, Comparer<int>.Default);
            PublishTest_OnAdd_Helper<string>("Test", Comparer<string>.Default);

            Person person = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith"
            };
            PublishTest_OnAdd_Helper<Person>(person, PersonIdComparer.Instance);
        }

        private void PublishTest_OnAdd_Helper<T>(T element, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);

            var expectedAction = ActionType.Add;
            var expectedValue = element;

            // Act
            CollectionChangedEventArgs<T> actual = null;
            collection.CollectionChanged += (s, e) => actual = e;

            collection.Add(element);

            // Assert
            Assert.AreEqual(expectedAction, actual.Action);
            Assert.AreEqual(expectedValue, actual.Value);
        }

        [TestMethod()]
        public void PublishTest_OnRemove()
        {
            int[] intArr = { 1, 5, 8, 4, 3, 8, 345, 7, 3, 2, 8, 8, 554, 6 };
            PublishTest_OnRemove_Helper<int>(intArr, Comparer<int>.Default);

            string[] stringArr = { "some", "values", "to", "test" };
            PublishTest_OnRemove_Helper<string>(stringArr, Comparer<string>.Default);

            Person[] people =
            {
                new Person() { Id = 1, FirstName = "John", LastName = "Smith"},
                new Person() { Id = 2, FirstName = "Derek", LastName = "Due"},
                new Person() { Id = 3, FirstName = "Ben", LastName = "Cohen"}
            };
            PublishTest_OnRemove_Helper<Person>(people, PersonIdComparer.Instance);
        }

        private void PublishTest_OnRemove_Helper<T>(T[] elements, IComparer<T> comparer)
        {
            // Arrange
            var collection = GetInstance<T>(comparer);
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Add(elements[i]);
            }

            Array.Sort(elements, comparer);

            var expectedAction = ActionType.Remove;
            var expectedValue = elements.Last();

            // Act
            CollectionChangedEventArgs<T> actual = null;
            collection.CollectionChanged += (s, e) => actual = e;

            collection.Remove();

            // Assert
            Assert.AreEqual(expectedAction, actual.Action);
            Assert.AreEqual(expectedValue, actual.Value);
        }

        [TestMethod()]
        public void Add_TimeComplexityTest()
        {
            var random = new Random();
            var maxRandValue = 50000;
            var measurementTimes = 5;

            int[] numOfElements = { 10, 100, 1000, 10000, 100000 };
            var results = new double[measurementTimes];

            for (int i = 0; i < results.Length; i++)
            {
                var collection = PopulateCollection(numOfElements[i]);

                var tempResults = new double[measurementTimes];
                for (int j = 0; j < measurementTimes; j++)
                {
                    var watch = Stopwatch.StartNew();
                    collection.Add(random.Next(maxRandValue));

                    watch.Stop();
                    tempResults[j] = watch.Elapsed.TotalMilliseconds;
                }

                results[i] = tempResults.Average();
                Console.WriteLine("Number of elements: " + numOfElements[i] + ", Add operation took: " + results[i] + " ms");
            }
        }

        [TestMethod()]
        public void Remove_TimeComplexityTest()
        {
            var measurementTimes = 5;

            int[] numOfElements = { 10, 100, 1000, 10000, 100000 };
            var results = new double[measurementTimes];

            for (int i = 0; i < results.Length; i++)
            {
                var collection = PopulateCollection(numOfElements[i]);

                var tempResults = new double[measurementTimes];
                for (int j = 0; j < measurementTimes; j++)
                {
                    var watch = Stopwatch.StartNew();
                    collection.Remove();

                    watch.Stop();
                    tempResults[j] = watch.Elapsed.TotalMilliseconds;
                }

                results[i] = tempResults.Average();
                Console.WriteLine("Number of elements: " + numOfElements[i] + ", Remove operation took: " + results[i] + " ms");
            }
        }

        private QuickCollection<int> PopulateCollection(int numOfElements)
        {
            var random = new Random();
            var maxRandValue = 50000;
            var comparer = Comparer<int>.Default;
            var collection = GetInstance<int>(comparer);

            for (int i = 0; i < numOfElements; i++)
            {
                var randInt = random.Next(maxRandValue);
                collection.Add(randInt);
            }

            return collection;
        }
    }
}