using Shared.Models;

namespace WebAPI.Services;

public interface IAuthorizationService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}