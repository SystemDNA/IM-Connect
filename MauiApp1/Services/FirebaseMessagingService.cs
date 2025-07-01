using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace MauiApp1.Services
{
    public class FirebaseTokenRetriever : IFirebaseTokenRetriever
    {
        private readonly IDeviceRegistrationService _deviceRegistrationService;


        private const string TokenKey = "FirebaseToken";

        public FirebaseTokenRetriever(IDeviceRegistrationService deviceRegistrationService)
        {
            _deviceRegistrationService = deviceRegistrationService;
        }
        // This property holds the Firebase token. 
        // It has a public get accessor but a private set accessor, 
        // meaning that it can be publicly read, but only changed internally by the class.
        public string Token { get; private set; }

        // This method allows for the saving of a new Firebase token.
        // It takes in a string token and assigns it to the Token property.
        public void SaveToken(string token)
        {
            Token = token;
            Preferences.Set(TokenKey, token);


            var deviceId = DeviceIdService.GetOrCreateDeviceId();
            var platform = DeviceIdService.GetPlatformName();
            _ = _deviceRegistrationService.SendDeviceInfoToServerAsync(deviceId, token, platform);
        }

        public string GetToken()
        {
            return Preferences.Get(TokenKey, string.Empty);
        }
    }
}
