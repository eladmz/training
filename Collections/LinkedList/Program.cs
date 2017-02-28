using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> myIntList = new LinkedList<int>();

            myIntList.addLast(3);
            myIntList.addFirst(2);
            myIntList.addFirst(1);
            

            foreach (int val in myIntList )
            {
                Console.Write(val + ", ");
            }

            Console.ReadLine();
        }
    }
}
