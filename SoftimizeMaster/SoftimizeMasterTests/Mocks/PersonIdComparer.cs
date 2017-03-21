using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftimizeMasterTests.Mocks
{
    public class PersonIdComparer : IComparer<Person>
    {
        private static PersonIdComparer instance = new PersonIdComparer();
        public static PersonIdComparer Instance { get { return instance; } }

        private PersonIdComparer() { }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.Id.CompareTo(y.Id);
        }
    }
}
