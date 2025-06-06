using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace MauiApp1.Services
{
    public class BiometricAuthService
    {
        public async Task<bool> AuthenticateAsync()
        {
        if (DeviceInfo.Platform == DevicePlatform.iOS && DeviceInfo.DeviceType == DeviceType.Virtual)
        {
            Debug.WriteLine("Simulating successful biometric authentication in simulator.");
            return true; // For simulator testing
        }

        var result = await CrossFingerprint.Current.AuthenticateAsync(
            new AuthenticationRequestConfiguration("Authenticate", "Use your fingerprint / Face ID to access the app")
            {
                AllowAlternativeAuthentication = true,
                ConfirmationRequired = true,
                CancelTitle = "Cancel",
                FallbackTitle = "Use Passcode"
            });

        return result.Authenticated;
    

    }
    }
}
