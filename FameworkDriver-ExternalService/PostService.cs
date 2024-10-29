using System.Text.Json;
using InterfaceAdapter_Adapter.Dtos;
namespace FameworkDriver_ExternalService;

public class PostService : IExternalService<PostServiceDto>
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;

    public PostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    public async Task<IEnumerable<PostServiceDto>> GetContentAsync()
    {
        var response = await _httpClient.GetAsync(_httpClient.BaseAddress);

        response.EnsureSuccessStatusCode();
        var responseData = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<PostServiceDto>>(responseData, _options);
    }
}
