using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> presidents = new ObservableCollection<string>
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "George HW Bush"
            };
            foreach (string president in presidents)
                Console.WriteLine(president);
            Console.WriteLine();

            presidents.CollectionChanged += OnCollectionChanged;

            presidents.Add("Bill Clinton");

            foreach (string president in presidents)
                Console.WriteLine(president);
            Console.WriteLine();

            presidents.Remove("Jimmy Carter");

            foreach (string president in presidents)
                Console.WriteLine(president);

        }

        // stop the debugger on calls to this and examine e to see what properties are available
        // telling you what's changed in the collection
        static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Change made! Action: {0} - added item {1} to list", e.Action, e.NewItems[0]);
            }
            else
            {
                Console.WriteLine("Change made! Action: {0} - removed item {1} from list", e.Action, e.OldItems[0]);
            }
            
        }
    }
}
