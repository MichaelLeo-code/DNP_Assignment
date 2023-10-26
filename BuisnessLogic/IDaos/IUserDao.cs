using Shared.Models;

namespace Validation.IDaos;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> AuthorizeAsync(string userName);
    Task<User?> GetByUsernameAsync(string userName);
}