using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddToList
{
    class Program
    {
        static void Main(string[] args)
        {
            var presidents = new List<string>(12){
                "Jimmy Carter",
                "Ronald Reagan",
                "George HW Bush",
                "Bill Clinton",
                "George W Bush"
            };

            // adding an item to a list. 
            presidents.Add("Barack Obama");

            // two different ways of getting read-only access to the list - not really defend the list, still people can
            // access/modify it using reflection or other "complex" ways.
            var copy = new ReadOnlyCollection<string>(presidents);
            // var copy = presidents.AsReadOnly();

            BadCode(copy);
            foreach (string president in presidents)
                Console.WriteLine(president);
        }


        static void BadCode(IList<string> lst)
        {
            // this would throw an exception: lst is read-only
            //			lst.RemoveAt(2);
        }
    }
}
