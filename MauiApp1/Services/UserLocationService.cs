using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class UserLocationService
    {
        public async Task<(Location Location, string Country)> GetUserLocationAndCountryAsync()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(10)
                    });
                }

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location);
                    var placemark = placemarks?.FirstOrDefault();
                    var country = placemark?.CountryName ?? "Unknown";
                    return (location, country);
                }

                return (null, "Unknown");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting location/country: {ex.Message}");
                return (null, "Error");
            }
        }
    }
}