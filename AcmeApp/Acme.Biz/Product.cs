using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;

        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created");
            //this.ProductVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }

        public Product(int productId, string productName, string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }

            Console.WriteLine("Product instance has a name: " + ProductName);
        }
        #endregion

        #region Properties
        private string productName;

        public string ProductName
        {
            get
            {
                string formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public string ValidationMessage { get; private set; }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => this.Category + "-" + this.SequenceNumber;


        #endregion

        public string SayHello()
        {
            //Vendor vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from vendor");

            EmailService emailService = new EmailService();
            string confirmation = emailService.SendMessage("New Product", this.ProductName, "sales@abc.com");

            string result = LoggingService.LogAction("Saying hello");

            //if (AvailabilityDate.HasValue)
            //{
            //    return "Hello " + ProductName + " (" + ProductId + "): " + Description
            //    + " Available on: " + AvailabilityDate.Value.ToShortDateString();
            //}

            return "Hello " + ProductName + " (" + ProductId + "): " + Description
                + " Available on: " + AvailabilityDate?.ToShortDateString();
        }
    } 
}
