using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraDevProject.DAL
{
    /// <summary>
    /// Provides functionality to work with the data source
    /// </summary>
    public class DALManager
    {
        /// <summary>
        /// Get all the devices from the data source.
        /// </summary>
        /// <returns>Iterative collection of all the devices</returns>
        public async Task<IEnumerable<Devices>> GetAllDevices()
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    using (AteraDevServerEntities context = new AteraDevServerEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;

                        var devices = context.Devices.Include("Owners").ToList();

                        return devices;
                    }
                });

                return result;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DALManager.GetAllDevices Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get all the devices with the owner name from the data source.
        /// </summary>
        /// <param name="ownerName">The owner name of the devices</param>
        /// <returns>Iterative collection of all the devices with the owner name</returns>
        public async Task<IEnumerable<Devices>> GetDevicesByOwnerName(string ownerName)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    using (AteraDevServerEntities context = new AteraDevServerEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;

                        var devices = context.Devices
                            .Include("Owners")
                            .Where(device => string.Compare(device.Owners.FullName, ownerName, StringComparison.OrdinalIgnoreCase) == 0)
                            .ToList();

                        return devices;
                    }
                });

                return result;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DALManager.GetDevicesByOwnerName Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get all the devices with the owner's country from the data source.
        /// </summary>
        /// <param name="ownerCountry">The owner's country name</param>
        /// <returns>Iterative collection of all the devices from the owner's country</returns>
        public async Task<IEnumerable<Devices>> GetDevicesByOwnerCountry(string ownerCountry)
        {
            try
            {
                var result = await Task.Run(() =>
                {
                    using (AteraDevServerEntities context = new AteraDevServerEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;

                        var devices = context.Devices
                            .Include("Owners")
                            .Where(device => string.Compare(device.Owners.Country, ownerCountry, StringComparison.OrdinalIgnoreCase) == 0)
                            .ToList();

                        return devices;
                    }
                });

                return result;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("DALManager.GetDevicesByOwnerCountry Failed! Exception: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Generates unique device name.
        /// </summary>
        /// <param name="device">The device to generate the unique string for</param>
        /// <returns>Unique string of the device</returns>
        public static string GenerateDeviceUniqueName(Devices device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            return string.Join("_", device.DeviceId, device.Name, device.Created, device.OwnerId);
        }

        /// <summary>
        /// Get the total days passed since the device was created.
        /// </summary>
        /// <param name="device">The device to get the days passed for</param>
        /// <returns>Number of days passed since the device was created</returns>
        public static int DaysSinceDeviceWasCreated(Devices device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            var now = DateTime.Now;

            var timePassed = now.Subtract(device.Created);

            Console.WriteLine(timePassed);

            return (int)timePassed.TotalDays;
        }
    }
}
