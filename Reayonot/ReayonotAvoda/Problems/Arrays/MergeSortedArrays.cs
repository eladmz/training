using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /**
     * Brightcom
     * 
     * Sort between two sorted arrays so that the outcome is also a sorted array.
     * Do this in place - the first sorted array has enouph empty room left to add the second array
     * 
     */
    class MergeSortedArrays<T>
    {
        public List<T> MergeSorted(List<T> a, List<T> b, Func<T, T, bool> isLargerOrEqual)
        {
            if (b == null || b.Count == 0) return a;
            if (a == null || a.Count == 0) return b;

            int pointer = a.FindIndex(i => i == null);
            int LastPointer = a.Count - 1;

            for (int i = b.Count - 1; i > 0; i--)
            {
                if (isLargerOrEqual(a[pointer], b[i]))
                {
                    a[LastPointer] = a[pointer];
                    pointer--;
                }
                else
                {
                    a[LastPointer] = b[i];
                }

                LastPointer--;
            }

            return a;
        } 
    }
}
