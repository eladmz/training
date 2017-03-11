using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softimize
{
    /// <summary>
    /// Mock comparer for testing
    /// </summary>
    public class FirstNameComparer : IComparer<Person>
    {
        private static FirstNameComparer instance = new FirstNameComparer();
        public static FirstNameComparer Instance { get { return instance; } }

        private FirstNameComparer() { }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return String.Compare(x.GetFirstName(), y.GetFirstName());
        }
    }
}
