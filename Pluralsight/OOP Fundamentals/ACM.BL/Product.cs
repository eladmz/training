using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductDescription { get; set; }
        public string ProductName { get; set; }
        public Decimal? CurrentPrice { get; set; }


        public Product()
        {

        }

        public Product(int productId)
        {
            this.ProductId = productId;
        }

        /// <summary>
        /// Validates the product data.
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrWhiteSpace(ProductName) || CurrentPrice == null)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
