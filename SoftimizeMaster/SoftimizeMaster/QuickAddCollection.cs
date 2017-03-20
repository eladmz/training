using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftimizeMaster
{
    public class QuickAddCollection<T> : QuickCollection<T>
    {
        public QuickAddCollection(IComparer<T> comparer)
        {
            if (comparer == null) throw new ArgumentNullException("Comparer must not be null");

            this.collection = new LinkedList<T>();
            this.comparer = comparer;
        }

        protected override bool AddElement(T element)
        {
            throw new NotImplementedException();
        }

        protected override T RemoveElement()
        {
            throw new NotImplementedException();
        }
    }
}
