using MauiApp1.Components.Models;
using System.Net.Http.Json;
using System.Text.Json;
public class TemplateService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TemplateService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<TemplateDataContent>> GetContentData(int id, int fkicountryid)
    {
        var _http = _httpClientFactory.CreateClient("DynamicData");
        // Matches the route in your controller
        var requestUrl = $"api/template/{id}/{fkicountryid}";
        var response=  await _http.GetAsync(requestUrl);
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<TemplateDataContent>>(json);
            return result ?? new List<TemplateDataContent>();
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return null;
        }
    }
}
