using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    internal class NewsExpandingService
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public NewsExpandingService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<ExpandingData>> GetNewsExpandingDataAsync(int NewsID)
        {
            try
            {
                var _http = _httpClientFactory.CreateClient("DynamicData");
                var response = await _http.GetAsync($"api/NewsExpanding/{NewsID}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<ExpandingData>>(json);
                    return result ?? new List<ExpandingData>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
                //return response ?? new List<CountriesData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API call failed: {ex.Message}");
                return new List<ExpandingData>();
            }
        }

    }
}
