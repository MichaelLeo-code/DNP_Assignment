using Shared.DTOs;
using Shared.Models;

namespace Validation.ILogic;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);
}