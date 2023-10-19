﻿using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace WebAPI.Services;

public class AuthorizationService : IAuthorizationService
{

    private readonly IList<User> users = new List<User>
    {
        new User
        {
            Age = 20,
            Email = "michael.leo.dk@gmail.com",
            Domain = "cubeco",
            Name = "Michael Leo",
            Password = "onetwo3FOUR",
            Role = "Creator",
            Username = "cubeco",
            SecurityLevel = 4
        },
        new User
        {
            Age = 108,
            Email = "ded@gmail.com",
            Domain = "old",
            Name = "Oldie Ancient",
            Password = "incorrect",
            Role = "Student",
            Username = "ded",
            SecurityLevel = 2
        }
    };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list
        
        users.Add(user);
        
        return Task.CompletedTask;
    }
}