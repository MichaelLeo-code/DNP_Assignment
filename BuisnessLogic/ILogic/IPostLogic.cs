using Shared.DTOs;
using Shared.Models;

namespace Validation.ILogic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post> GetByIdAsync(int id);
}