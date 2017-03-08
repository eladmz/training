using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Tutorial02;

namespace Tutorial02Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(HelloService)))
            {
                host.Open();
                Console.WriteLine("Host started at : " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
