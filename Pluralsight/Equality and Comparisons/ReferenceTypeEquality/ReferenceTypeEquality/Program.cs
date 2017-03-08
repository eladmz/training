using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            Food apple = new Food("apple", FoodGroup.Fruit);
            CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);

            Console.WriteLine(apple);
            Console.WriteLine(stewedApple);
        }
    }
}
