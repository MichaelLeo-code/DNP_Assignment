using Shared.DTOs;

namespace HTTPServices.IServices;

public interface IPostService
{
    public Task PostAsync(string title, string body, int authorId);
}