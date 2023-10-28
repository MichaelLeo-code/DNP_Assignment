using System.ComponentModel;
using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string fileUsers = "users.json";
    private const string filePosts = "posts.json";
    private UserContainer? userContainer;
    private PostContainer? postContainer;

    public FileContext()
    {
        if (!File.Exists(fileUsers))
        {
            userContainer = new UserContainer()
            {
                Users = new List<User>()
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
                        SecurityLevel = 4,
                        Id = 1
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
                        SecurityLevel = 2,
                        Id = 2
                    }
                }
            };
        }
        if (!File.Exists(filePosts))
        {
            postContainer = new PostContainer()
            {
                Posts = new List<Post>()
            };
        }
    }
    
    public ICollection<User> Users
    {
        get
        {
            LoadUsers();
            return userContainer!.Users;
        }
    }
    
    public ICollection<Post> Posts
    {
        get
        {
            LoadPosts();
            return postContainer!.Posts;
        }
    }

    private void LoadPosts()
    {
        if (postContainer != null) return;
        string content = File.ReadAllText(filePosts); 
        postContainer = JsonSerializer.Deserialize<PostContainer>(content);
    }
    
    private void LoadUsers()
    {
        if (userContainer != null) return;
        string content = File.ReadAllText(fileUsers);
        userContainer = JsonSerializer.Deserialize<UserContainer>(content);
    }
    
    public void SaveChanges()
    {
        if (userContainer != null)
        {
            string serialized = JsonSerializer.Serialize(userContainer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(fileUsers, serialized);
            userContainer = null;
        }
        if (postContainer != null)
        {
            string serialized = JsonSerializer.Serialize(postContainer, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(filePosts, serialized);
            userContainer = null;
        }
    }
}