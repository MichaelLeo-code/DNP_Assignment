using Shared.DTOs;
using Shared.Models;

namespace Validation.ILogic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
}