using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class EventsDataService
    {
        private readonly HttpClient _http;

        public EventsDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EventItem>> GetEventsByCountryId(int countryId)
        {
            var result = await _http.GetFromJsonAsync<List<EventItem>>($"api/events/{countryId}");
            return result ?? new List<EventItem>();
        }
    }
}
