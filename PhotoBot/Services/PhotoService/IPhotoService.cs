using PhotoBot.Models;

namespace PhotoBot.Services.PhotoService;

public interface IPhotoService
{
    public Task<Photo?> GetPhotoAsync(string query);
}