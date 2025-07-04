using MauiApp1.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    class NewsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<News>> GetNewsAsync(int Eventid,int CountryID)
        {
            try
            {
                var _http = _httpClientFactory.CreateClient("DynamicData");
                var requestUrl = $"api/news/{Eventid}/{CountryID}";
                return await _http.GetFromJsonAsync<List<News>>(requestUrl)
                       ?? new List<News>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message.ToString());
                return null;
            }
        }
        public async Task<List<NewsContent>> GetNewsContentAsync(int EventID)
        {
            try {
                var _http = _httpClientFactory.CreateClient("DynamicData");
                var requestUrl = $"api/news/newscontent/{EventID}";
            return await _http.GetFromJsonAsync<List<NewsContent>>(requestUrl)
                   ?? new List<NewsContent>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
                return null;

            }
        }

    }
}
