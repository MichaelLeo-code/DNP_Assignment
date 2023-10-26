namespace Shared.DTOs;

public class UserCreationDto
{
    public string Username { get; init; }
    public string Password { get; init; }
    public string Email { get; init; }
    public string Domain { get; init; }
    public string Name { get; init; }
    public string Role { get; init; }
    public int Age { get; init; }
    public int SecurityLevel { get; init; }
}