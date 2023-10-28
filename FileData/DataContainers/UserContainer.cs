using System.Text.Json;
using Shared.Models;

namespace FileData;

public class UserContainer
{
    public ICollection<User> Users { get; set; }
}