using System.Text.Json;
using Shared.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private DataContainer? dataContainer;

    public FileContext()
    {
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
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
    }
    
    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer!.Users;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
    
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}