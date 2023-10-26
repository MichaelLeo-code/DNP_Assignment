using Shared.DTOs;
using Shared.Models;
using Validation.IDaos;
using Validation.ILogic;

namespace Validation.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}