using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonBlankStringList
{
    class NonBlankStringList : Collection<string>
    {
        protected override void InsertItem(int index, string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Elements of NonBlankStringList must not be null or whitespace");
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException("Elements of NonBlankStringList must not be null or whitespace");
            base.SetItem(index, item);
        }
    }
}
