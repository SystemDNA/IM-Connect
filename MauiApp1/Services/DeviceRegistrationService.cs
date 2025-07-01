using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class DeviceRegistrationService : IDeviceRegistrationService
    {

        public DeviceRegistrationService()
        {

        }

        public async Task SendDeviceInfoToServerAsync(string deviceId, string firebaseToken, string platform)
        {
            var payload = new
            {
                deviceId,
                firebaseToken,
                platform
            };

        }
    }
}
