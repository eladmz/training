using Microsoft.VisualStudio.TestTools.UnitTesting;
using Softimize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Softimize.Tests
{
    [TestClass()]
    public class PersonCollectionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTest_Null()
        {
            var persons = new PersonCollection(FirstNameComparer.Instance);

            persons.Add(null);
        }

        [TestMethod()]
        public void AddTest_FirstNameComparer()
        {
            var persons = new PersonCollection(FirstNameComparer.Instance);
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));

            var expected = new List<Person>()
            {
                new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)),
                new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)),
                new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)),
                new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)),
                new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)),
                new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)),
                new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)),
                new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25))
            };

            int i = 0;
            foreach (var actual in persons)
            {
                Assert.AreEqual(expected[i], actual);
                i++;
            }
        }

        [TestMethod()]
        public void AddTest_IdComparer()
        {
            var persons = new PersonCollection(IdComparer.Instance);
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));


            var expected = new List<Person>()
            {
                new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)),
                new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)),
                new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)),
                new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)),
                new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)),
                new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)),
                new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)),
                new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25))
            };

            int i = 0;
            foreach (var actual in persons)
            {
                Assert.AreEqual(expected[i], actual);
                i++;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveTest_Empty()
        {
            var persons = new PersonCollection(FirstNameComparer.Instance);

            persons.Remove();
        }

        [TestMethod()]
        public void RemoveTest_FirstNameComparer()
        {
            var persons = new PersonCollection(FirstNameComparer.Instance);
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));

            var actual = persons.Remove();

            var expected = new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveTest_IdComparer()
        {
            var persons = new PersonCollection(IdComparer.Instance);
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)));

            var actual = persons.Remove();

            var expected = new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PublishTest_Add()
        {
            string message = "";

            var persons = new PersonCollection(IdComparer.Instance);
            persons.CollectionChanged += delegate (object sender, CollectionChangedEventArgs args)
            {
                Console.WriteLine(args.Message);
                message = args.Message;
            };
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));

            var actual = message;

            var expected = "Added person 1 : John Smith to the collection";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PublishTest_Remove()
        {
            string message = "";

            var persons = new PersonCollection(IdComparer.Instance);
            persons.CollectionChanged += delegate (object sender, CollectionChangedEventArgs args)
            {
                Console.WriteLine(args.Message);
                message = args.Message;
            };
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Remove();

            var actual = message;

            var expected = "Removed person 1 : John Smith from the collection";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PublishTest_AddAndRemove()
        {
            var messages = new List<string>();

            var persons = new PersonCollection(IdComparer.Instance);
            persons.CollectionChanged += delegate (object sender, CollectionChangedEventArgs args)
            {
                Console.WriteLine(args.Message);
                messages.Add(args.Message);
            };
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Remove();
            persons.Remove();
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Remove();

            var actual = messages;

            var expected = new List<string>()
            {
                "Added person 1 : John Smith to the collection",
                "Added person 7 : Ben Dark to the collection",
                "Added person 2 : Derek Due to the collection",
                "Removed person 7 : Ben Dark from the collection",
                "Removed person 2 : Derek Due from the collection",
                "Added person 2 : Derek Due to the collection",
                "Removed person 2 : Derek Due from the collection"
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PublishTest_ReceivedEvents()
        {
            int receivedEvents = 0;

            var persons = new PersonCollection(IdComparer.Instance);
            persons.CollectionChanged += delegate(object sender, CollectionChangedEventArgs args)
            {
                Console.WriteLine(args.Message);
                receivedEvents++;
            };
            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
            persons.Remove();
            persons.Add(new MyPerson(2, "Derek", "Due", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(7, "Ben", "Dark", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(6, "Eli", "Cohen", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(4, "Led", "Zeplin", 168, new DateTime(1990, 11, 25)));
            persons.Remove();
            persons.Add(new MyPerson(3, "Ana", "Frank", 168, new DateTime(1990, 11, 25)));
            persons.Add(new MyPerson(5, "May", "Pluck", 168, new DateTime(1990, 11, 25)));
            persons.Remove();


            var actual = receivedEvents;

            var expected = 10;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddTest_IdComparer_MultiThreading()
        {
            var persons = new PersonCollection(IdComparer.Instance);

            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (j % 2 == 0)
                            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
                        else
                            persons.Add(new MyPerson(2, "Eric", "Due", 168, new DateTime(1990, 11, 25)));
                    }
                });
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }


            var expected = 10000;

            Assert.AreEqual(expected, persons.Count());
        }

        [TestMethod()]
        public void AddAndRemoveTest_IdComparer_MultiThreading()
        {
            var persons = new PersonCollection(IdComparer.Instance);

            for (int i = 0; i < 5000; i++)
            {
                if (i % 2 == 0)
                    persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
                else
                    persons.Add(new MyPerson(2, "Eric", "Due", 168, new DateTime(1990, 11, 25)));
            }

            Thread[] addThreads = new Thread[5];
            for (int i = 0; i < addThreads.Length; i++)
            {
                addThreads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (j % 2 == 0)
                            persons.Add(new MyPerson(1, "John", "Smith", 168, new DateTime(1990, 11, 25)));
                        else
                            persons.Add(new MyPerson(2, "Eric", "Due", 168, new DateTime(1990, 11, 25)));
                    }
                });
            }

            Thread[] removeThreads = new Thread[5];
            for (int i = 0; i < addThreads.Length; i++)
            {
                removeThreads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        persons.Remove(); 
                    }
                });
            }

            for (int i = 0; i < addThreads.Length; i++)
            {
                addThreads[i].Start();
                removeThreads[i].Start();
            }

            for (int i = 0; i < addThreads.Length; i++)
            {
                addThreads[i].Join();
                removeThreads[i].Join();
            }


            var expected = 5000;

            Assert.AreEqual(expected, persons.Count());
        }
    }
}