namespace Shared.Models;

public class Post
{
    public string title { get; set; }
    public string body { get; set; }
    public int authorId { get; set; }
    public string authorUsername { get; set; }
    public int postId { get; set; }
}