using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public static class DeviceIdService
    {
        private const string DeviceIdKey = "DeviceUniqueId";
        private const string PlatformKey = "PlatformName";

        public static string GetOrCreateDeviceId()
        {
            if (!Preferences.ContainsKey(DeviceIdKey))
            {
                // Generate new values on first run
                string newId = Guid.NewGuid().ToString();
                Preferences.Set(DeviceIdKey, newId);
                Preferences.Set(PlatformKey, GetPlatformName());
            }

            return Preferences.Get(DeviceIdKey, string.Empty);
        }

        public static string GetPlatformName()
        {
            var platform = DeviceInfo.Platform;

            if (platform == DevicePlatform.iOS)
                return "iOS";
            else if (platform == DevicePlatform.Android)
                return "Android";
            else if (platform == DevicePlatform.MacCatalyst)
                return "Mac";
            else if (platform == DevicePlatform.macOS)
                return "macOS";
            else if (platform == DevicePlatform.WinUI)
                return "Windows";
            // Uncomment below if Tizen support is added
            // else if (platform == DevicePlatform.Tizen)
            //     return "Tizen";
            else
                return "Unknown";
        }

        public static string GetStoredPlatform()
        {
            return Preferences.Get(PlatformKey, GetPlatformName()); // fallback to current
        }
    }
}
