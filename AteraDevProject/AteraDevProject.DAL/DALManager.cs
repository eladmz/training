using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AteraDevProject.DAL
{
    public class DALManager
    {
        public async Task<ICollection<Devices>> GetAllDevices()
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
            catch (Exception e)
            {
                Console.WriteLine("DALManager.GetAllDevices Failed! Exception: " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

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
            catch (Exception e)
            {
                Console.WriteLine("DALManager.GetDevicesByOwnerName Failed! Exception: " + e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public static string GenerateDeviceUniqueName(Devices device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }
            return string.Join("_", device.DeviceId, device.Name, device.Created, device.OwnerId);
        }

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
