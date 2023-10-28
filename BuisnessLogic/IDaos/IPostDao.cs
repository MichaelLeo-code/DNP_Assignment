using Shared.Models;

namespace Validation.IDaos;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIsAsync(int id);
}