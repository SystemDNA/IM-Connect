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
        private readonly HttpClient _http;

        public NewsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<News>> GetNewsAsync(int Eventid)
        {
            try
            {
                var requestUrl = $"api/news/{Eventid}";
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
