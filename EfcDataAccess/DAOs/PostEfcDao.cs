using EfcDataAccess;
using Shared.Models;
using Validation.IDaos;

namespace FileData.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly EFCContext context;

    public PostEfcDao(EFCContext context)
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
        context.SaveChangesAsync();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        //optionally apply search parameters
        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIsAsync(int id)
    {
        Post? post = context.Posts.FirstOrDefault(p => p.postId == id);
        return Task.FromResult(post);
    }
}