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
                var response= await _http.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<News>>(json);
                    return result ?? new List<News>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
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
                var response= await _http.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<NewsContent>>(json);
                    return result ?? new List<NewsContent>();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
                return null;

            }
        }

    }
}
