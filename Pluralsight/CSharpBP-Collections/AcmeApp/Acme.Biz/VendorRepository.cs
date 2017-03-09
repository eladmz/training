using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> vendors;

        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        /// <summary>
        /// Retrieve all the approved vendor.
        /// </summary>
        public List<Vendor> Retrieve()
        {
            if (vendors == null)
            {
                vendors = new List<Vendor>();

                vendors.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
                vendors.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" });
            }

            foreach (var vendor in vendors)
            {
                Console.WriteLine(vendor);
            }

            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine(vendors[i]);
            }

            return vendors;
        }

        /// <summary>
        /// Retrieve all the approved vendor.
        /// </summary>
        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                { "ABC Corp", new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { "XYZ Corp", new Vendor() { VendorId = 2, CompanyName = "XYZ Corp", Email = "xyz@xyz.com" } }
            };

            foreach (var companyName in vendors.Keys)
            {
                Console.WriteLine(companyName);
            }

            foreach (var ven in vendors.Values)
            {
                Console.WriteLine(ven);
            }

            foreach (var element in vendors)
            {
                Console.WriteLine($"{element.Key} : {element.Value}");
            }

            if (vendors.ContainsKey("XYZ"))
            {
                Console.WriteLine(vendors["XYZ"]);
            }

            Vendor vendor;
            if (vendors.TryGetValue("XYZ", out vendor))
            {
                Console.WriteLine(vendor);
            }

            return vendors;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public T RetrieveValue<T>(string sql, T defaultValue)
        {
            // Call the database to retrieve the value
            // If no value is returned, return the default value
            T value = defaultValue;

            return value;
        }
    }
}
