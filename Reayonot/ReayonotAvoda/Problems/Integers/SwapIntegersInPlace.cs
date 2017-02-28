using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems
{
    /**
     * Brightcom
     * 
     * The question was how do you swap to integers in place
     */
    class SwapIntegersInPlace
    {
        public int[] SwapInPlace(int a, int b)
        {
            b += a; // a = a, b = a + b
            a -= b; // a = -b, b = a + b
            b += a; // a = -b, b = a
            a *= -a; // a = b, b = a

            return new []{a, b};
        }

    }
}
