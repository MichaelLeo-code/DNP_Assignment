using System.IO.Compression;
using Shared.Models;

namespace FileData;

public class PostContainer
{
    public ICollection<Post> Posts { get; set; }
}