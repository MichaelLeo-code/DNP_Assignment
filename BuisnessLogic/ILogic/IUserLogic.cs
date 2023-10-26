using Shared.DTOs;
using Shared.Models;

namespace Validation.ILogic;

public interface IUserLogic
{
    Task<User> ValidateUser(string username, string password);
    Task<User> CreateAsync(UserCreationDto dto);
}