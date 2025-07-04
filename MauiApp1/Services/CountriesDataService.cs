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
        private readonly IHttpClientFactory _httpClientFactory;

        public CountriesDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CountriesData>> GetCountriesDataAsync(int countryid)
        {
            try
            {
                var _http = _httpClientFactory.CreateClient("DynamicData");
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
