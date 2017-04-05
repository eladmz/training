using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.HelloWorldServiceReference;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HelloWorldClient("NetTcpBinding_IHelloWorld");
            var person = new Name()
            {
                First = "Elad",
                Last = "Mizrahi"
            };

            Console.WriteLine(client.SayHello(person));
            Console.ReadLine();
        }
    }
}
