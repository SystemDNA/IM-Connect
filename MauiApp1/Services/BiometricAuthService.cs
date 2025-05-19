using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class BiometricAuthService
    {
        public async Task<bool> AuthenticateAsync()
        {
            var result = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration(
                "Authenticate", "Use your fingerprint / Face ID to access the app")
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
