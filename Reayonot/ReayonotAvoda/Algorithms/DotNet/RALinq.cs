using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Algorithms.DotNet
{
    static class RALinq<T>
    {
        /**
         * The linq statements are very efficient at times because of the fact that they are only called once
         * a method makes use of the Ineumerable they return - transforms it into something else. This can make the
         * runtime shorter since the linq will only be called to return the amount of elements that are needed and
         * will not necacerily go over all the elements it is provided (if it only needs the first 10 elements it will
         * stop its run once it has them and not continue to go over the rest of the content).
         * This is in fact made possible by the yeild return which returns an element at a time and saves using the yield
         * the position in the list being checked so that it continues from the position when looking for the next element.
         */
        public static IEnumerable<T> RAWhere(List<T> listList, Func<T, bool> functionFunc)
        {
            foreach (T VARIABLE in listList)
            {
                if (functionFunc(VARIABLE))
                {
                    yield return VARIABLE;
                }
            }
        } 
    }
}
