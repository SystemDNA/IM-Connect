using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    internal class CountriesListService
    {
        private readonly HttpClient _http;

        public CountriesListService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CountryLists>> GetCountriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CountryLists>>("api/countries") ?? new List<CountryLists>();
            //return result ?? new List<CountryLists>();
        }


        public async Task AddPCountriesAsync(CountryLists list)
        {
            var response = await _http.PostAsJsonAsync("api/Countries", list);
            response.EnsureSuccessStatusCode();
        }
    }
}
