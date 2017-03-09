using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public enum IncludeAddress { Yes, No };
        public enum SendCopy { Yes, No };

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <param name="deliveryBy">Requested delivery date.</param>
        /// <param name="instructions">Delivery instructions.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliveryBy = null, string instructions = "standard delivery")
        {
            if (product == null)
                throw new ArgumentNullException("Product is null");
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException("Quantity must be greater than 0");
            if (deliveryBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException("Delivery date must be later than now");

            bool success = false;

            StringBuilder orderTextBuilder = new StringBuilder("Order from Acme, Inc" + Environment.NewLine +
                               "Product: " + product.ProductCode + Environment.NewLine +
                               "Quantity: " + quantity);
            if (deliveryBy.HasValue)
            {
                orderTextBuilder.Append(Environment.NewLine + "Deliver By: " + deliveryBy.Value.ToString("d"));
            }
            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderTextBuilder.Append(Environment.NewLine + "Instructions: " + instructions);
            }
            string orderText = orderTextBuilder.ToString();

            EmailService emailService = new EmailService();
            string confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }
            OperationResult operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="includeAddress">True to include the shipping address</param>
        /// <param name="sendCopy">True to send a copy of the mail to the current</param>
        /// <returns>Success flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quantity, IncludeAddress includeAddress, SendCopy sendCopy)
        {
            string orderText = "Test";
            if (includeAddress == IncludeAddress.Yes)
                orderText += " With Address";
            if (sendCopy == SendCopy.Yes)
                orderText += " With Copy";

            OperationResult operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + this.CompanyName;
            string result;
            result = vendorInfo.ToLower();
            result = vendorInfo.ToUpper();
            result = vendorInfo.Replace("Vendor", "Supplier");

            int length = vendorInfo.Length;
            int index = vendorInfo.IndexOf(":");
            bool begins = vendorInfo.StartsWith("Vendor");

            return vendorInfo;
        }

        public string PrepareDirections()
        {
            string directions = @"Insert \r\n to define a new line";
            return directions;
        }
    }
}
