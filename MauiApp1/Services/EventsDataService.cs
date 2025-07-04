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
        private readonly IHttpClientFactory _httpClientFactory;

        public EventsDataService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<EventItem>> GetEventsByCountryId(int countryId)
        {
             var _http = _httpClientFactory.CreateClient("DynamicData");
            var result = await _http.GetFromJsonAsync<List<EventItem>>($"api/events/{countryId}");
            return result ?? new List<EventItem>();
        }
    }
}
