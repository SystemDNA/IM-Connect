using System.Net.Http.Json;
using MauiApp1.Components.Models;
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
        return await _http.GetFromJsonAsync<List<TemplateDataContent>>(requestUrl)
               ?? new List<TemplateDataContent>();
    }
}
