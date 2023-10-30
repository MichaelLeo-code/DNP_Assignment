using Shared.DTOs;
using Shared.Models;

namespace HTTPServices.IServices;

public interface IPostService
{
    public Task<HttpResponseMessage> PostAsync(string title, string body, int authorId, string authorUsername);
    public Task<IEnumerable<Post>> GetAsync();
    public Task<Post> GetByIdAsync(int id);
}