//using Intents;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public CountriesListService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<CountryLists>> GetCountriesAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("DynamicData");
                var response = await client.GetFromJsonAsync<List<CountryLists>>("api/countries") ?? new List<CountryLists>();
                return response;
            }
            catch(Exception ex)
            {
                return null;
            }
            //return result ?? new List<CountryLists>();
        }


        //public async Task AddPCountriesAsync(CountryLists list)
        //{
        //    var response = await _http.PostAsJsonAsync("api/Countries", list);
        //    response.EnsureSuccessStatusCode();
        //}
    }
}
