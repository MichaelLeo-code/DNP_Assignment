using System.ComponentModel.DataAnnotations;
using Shared.DTOs;
using Shared.Models;
using Validation.IDaos;
using Validation.ILogic;

namespace Validation.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao dao)
    {
        this.userDao = dao;
    }

    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await userDao.GetByUsernameAsync(username);
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
    
    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Age = dto.Age,
            Domain = dto.Domain,
            Email = dto.Email,
            Name = dto.Name,
            Role = dto.Role,
            SecurityLevel = dto.SecurityLevel
        };
    
        User created = await userDao.CreateAsync(toCreate);
    
        return created;
    }
    
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;

        if (string.IsNullOrEmpty(userName))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(userToCreate.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        
        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
    }
}