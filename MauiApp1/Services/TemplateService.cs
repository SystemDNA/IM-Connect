using System.Net.Http.Json;
using MauiApp1.Components.Models;
public class TemplateService
{
    private readonly HttpClient _http;

    public TemplateService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TemplateDataContent>> GetContentData(int id, int fkicountryid)
    {
        // Matches the route in your controller
        var requestUrl = $"api/template/{id}/{fkicountryid}";
        return await _http.GetFromJsonAsync<List<TemplateDataContent>>(requestUrl)
               ?? new List<TemplateDataContent>();
    }
}
