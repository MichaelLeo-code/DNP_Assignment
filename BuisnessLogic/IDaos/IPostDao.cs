using Shared.Models;

namespace Validation.IDaos;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
}