using EfcDataAccess;
using Shared.Models;
using Validation.IDaos;

namespace FileData.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly EFCContext context;
    
    public UserEfcDao(EFCContext context)
    {
        this.context = context;
    }
    
    public Task<User> CreateAsync(User user)
    {
        int userId = 1;
        if (context.Users.Any())
        {
            userId = context.Users.Max(u => u.Id);
            userId++;
        }

        user.Id = userId;

        context.Users.Add(user);
        context.SaveChangesAsync();

        return Task.FromResult(user);
    }

    public Task<User?> AuthorizeAsync(string userName)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = context.Users.FirstOrDefault(u =>
            u.Username.ToLower().Equals(userName.ToLower())
        );
        return Task.FromResult(existing);
    }
}