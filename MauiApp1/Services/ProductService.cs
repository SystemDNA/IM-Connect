using System.Net.Http.Json;
using MauiApp1.Components.Models;

namespace MauiApp1.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/products") ?? new List<Product>();
        }

        public async Task AddProductAsync(Product product)
        {
            var response = await _http.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
        }
    }

}
