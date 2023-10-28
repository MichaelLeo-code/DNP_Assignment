using Shared.Models;
using Validation.IDaos;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(u => u.postId);
            postId++;
        }

        post.postId = postId;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }
}