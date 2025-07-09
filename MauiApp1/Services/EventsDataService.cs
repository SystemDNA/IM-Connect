using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class EventsDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EventsDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<EventItem>> GetEventsByCountryId(int countryId)
        {
             var _http = _httpClientFactory.CreateClient("DynamicData");
            var response = await _http.GetAsync($"api/events/{countryId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<EventItem>>(json);
                return result ?? new List<EventItem>();
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }
    }
}
