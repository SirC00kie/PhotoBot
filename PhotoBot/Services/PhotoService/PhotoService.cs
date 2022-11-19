using Newtonsoft.Json;
using PhotoBot.Models;

namespace PhotoBot.Services.PhotoService;

public class PhotoService : IPhotoService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PhotoService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Photo?> GetPhotoAsync(string query)
    {
        var client = _httpClientFactory.CreateClient("photo");
        
        var apiKey = Environment.GetEnvironmentVariable("apiKey");

        var uriBuilder = new UriBuilder
        {
            Scheme = "http",
            Host = "api.unsplash.com",
            Path = "/photos/random",
            Query = $"query={query}&client_id={apiKey}",
        };
        var uri = uriBuilder.Uri;
        
        try
        {
            var stringResult = await client.GetStringAsync(uri);
            var photo = JsonConvert.DeserializeObject<Photo>(stringResult);
            return photo;
        }
        catch
        {
            return default;
        }
    }
}