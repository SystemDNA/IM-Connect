using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    internal class CountriesDataService
    {
        private readonly HttpClient _http;

        public CountriesDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CountriesData>> GetCountriesDataAsync(int countryid)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<CountriesData>>($"api/countriesdata/{countryid}");
                return response ?? new List<CountriesData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API call failed: {ex.Message}");
                return new List<CountriesData>();
            }
        }

    }
}
