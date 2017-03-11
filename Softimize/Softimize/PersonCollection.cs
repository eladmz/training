using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Softimize
{
    /// <summary>
    /// Manages the collection of persons.
    /// </summary>
    public class PersonCollection: IEnumerable<Person>
    {
        private LinkedList<Person> persons;
        private IComparer<Person> personComparer;

        public delegate void CollectionChangedEventHandler(object sender, CollectionChangedEventArgs args);
        public event CollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// Creates instance of PersonCollection with the given person comparer.
        /// </summary>
        /// <param name="personComparer">Specify how person objects will be ordered.</param>
        public PersonCollection(IComparer<Person> personComparer)
        {
            persons = new LinkedList<Person>();
            this.personComparer = personComparer;
        }

        /// <summary>
        /// Adds a person to the sorted collection according to the comparer.
        /// </summary>
        /// <param name="person">The person to add to the collection.</param>
        public void Add(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("Person must be not null");

            lock (persons)
            {
                if (persons.Count == 0 || personComparer.Compare(person, persons.First.Value) <= 0)
                {
                    persons.AddFirst(person);
                }     
                else if (personComparer.Compare(person, persons.Last.Value) >= 0)
                {
                    persons.AddLast(person);
                }
                else
                {
                    var greaterPersonNode = persons.First;

                    while (personComparer.Compare(person , greaterPersonNode.Value) > 0)
                    {
                        greaterPersonNode = greaterPersonNode.Next;
                    }

                    persons.AddBefore(greaterPersonNode, person);
                }
            }

            var message = String.Format("Added person {0} to the collection", person);
            var args = new CollectionChangedEventArgs(message);

            Publish(args);
        }

        /// <summary>
        /// Removes the person with the maximum value and returns it.
        /// </summary>
        /// <returns>The person with the maximum value.</returns>
        public Person Remove()
        {
            lock (persons)
            {
                if (persons.Count == 0)
                    throw new IndexOutOfRangeException("The collection is empty.");

                Person maxPerson = persons.Last.Value;
                persons.RemoveLast();

                var message = String.Format("Removed person {0} from the collection", maxPerson);
                var args = new CollectionChangedEventArgs(message);

                Publish(args);

                return maxPerson;
            }
        }

        /// <summary>
        /// publishes notification to anyone subscribed to the event.
        /// </summary>
        /// <param name="args"></param>
        private void Publish(CollectionChangedEventArgs args)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, args);
            }
        }

        /// <summary>
        /// Returns an enumarator that iterates through the person collection.
        /// </summary>
        public IEnumerator<Person> GetEnumerator()
        {
            return persons.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumarator that iterates through the person collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
