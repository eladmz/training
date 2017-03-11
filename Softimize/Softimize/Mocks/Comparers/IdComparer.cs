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
    public class IdComparer : IComparer<Person>
    {
        private static IdComparer instance = new IdComparer();
        public static IdComparer Instance { get { return instance; } }

        private IdComparer() { }

        public int Compare(Person x, Person y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.GetId().CompareTo(y.GetId());
        }
    }
}
