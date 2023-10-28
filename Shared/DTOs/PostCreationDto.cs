namespace Shared.DTOs;

public class PostCreationDto
{
    public string title { get; init; }
    public string body { get; init; }
    public int authorId { get; init; }
    public string authorUsername { get; init; }
}