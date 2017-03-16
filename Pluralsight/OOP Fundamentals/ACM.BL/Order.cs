using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        public int OrderId { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }

        public Order()
        {

        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }

        /// <summary>
        /// Validates the order data.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var isValid = true;

            if (OrderDate == null)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
