using DataPatrolDesktop.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _client;

    public ApiService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:5001");
    }

    public async Task<UserRegisterResponse?> RegisterUserAsync(string username)
    {
        var payload = JsonSerializer.Serialize(new { username });
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/reg", content);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<UserRegisterResponse>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<long?> CreateRequestAsync(UserRequestDto request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/request/create", content);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(result);
        return doc.RootElement.GetProperty("requestId").GetInt64();
    }

    public async Task<Dictionary<string, int>?> GetSummaryAsync(string userId)
    {
        var json = JsonSerializer.Serialize(new { userId });
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/request/summary", content);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Dictionary<string, int>>(result);
    }
}
