using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReayonotAvoda
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<int> {1, 2, 3, 40, 100, 1000};
            
            var newList = myList.Where(num => num > 10).Select(n => n + 1);
            
            foreach (var i in newList)
            {
                
            }


            
            /**
             * TODO:
             * arrays: 
             *      mergesortedarrays
             *      anagrams
             * logicalquestions: 
             *      horse races
             *Algorithms:
             *      All
             *DataStructers:
             *      Hash
             *      Trees
             * Design Patterns:
             *      All
             *
             */
        }

        
    }

    public class Extensions
    {
        //public static IEnumerable<int> MyLinq(this List<int> nums, Func<int, bool> predicate)
        //{
        //    foreach (var num in nums)
        //    {
        //        if (predicate(num))
        //        {
        //            yield return num;
        //        }
        //    }
        //}

        public async Task DoSomething()
        {
            var result = DoSomethingElse();
        }

        private async Task<int> DoSomethingElse()
        {
            throw new NotImplementedException();
        }
    }
}
