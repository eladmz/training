using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = { 3, 5, 4, 8, 6, 7, 5, 2, 1, 0, 9, 8, 5, 6, 11, 13, 19, 11, 12, 14, 16, 15, 20, 19 };

            //Sorting.BubbleSort(ref intArr);
            //Sorting.SelectionSort(ref intArr);
            Sorting.InsertionSort(ref intArr);

            Console.WriteLine();

            Searching.BinarySearch(intArr, 10);
            Searching.BinarySearch(intArr, 1);

            string[] strArr = { "Dog", "Apple", "Cat", "Noodle", "Chop", "Elephant", "Balls", "Balling" };

            //Sorting.BubbleSort<string>(ref strArr);
            //Sorting.SelectionSort(ref strArr);
            Sorting.InsertionSort(ref strArr);

            Console.WriteLine();

            Searching.BinarySearch(strArr, "Bro");
            Searching.BinarySearch(strArr, "Balls");


            MyStack<int> stack = new MyStack<int>(10);
            stack.Push(2);
            stack.Push(3);
            stack.Push(15);
            Console.WriteLine(stack);
            stack.Peek();
            stack.Pop();
            stack.Push(1);
            Console.WriteLine(stack);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
