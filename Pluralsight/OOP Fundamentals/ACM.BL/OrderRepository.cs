using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderRepository
    {
        /// <summary>
        /// Retrieve one order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Retrieve(int orderId)
        {
            // Create the instance of the Order class
            // Pass in the requested Id
            Order order = new Order(orderId);

            // Code that retrieves the defined order

            // Temporary hard coded values to return a populate order
            if (orderId == 10)
            {
                order.OrderDate = new DateTimeOffset(2014, 15, 01, 15, 55, 23, new TimeSpan(0));
            }

            return order;
        }

        /// <summary>
        /// Saves the current order.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined order
            return true;
        }
    }
}
