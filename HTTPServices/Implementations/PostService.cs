using System.Security.Claims;
using System.Text;
using System.Text.Json;
using HTTPServices.IServices;
using Shared.DTOs;
using Shared.Models;

namespace HTTPServices.Implementations;

public class PostService : IPostService
{
    private HttpClient client;
    
    public PostService(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task PostAsync(string title, string body, int authorId, string authorUsername)
    {
        PostCreationDto postDto = new()
        {
            title = title,
            body = body,
            authorId = authorId,
            authorUsername = authorUsername
        };
        
        string userAsJson = JsonSerializer.Serialize(postDto);
        StringContent content = new(userAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("http://localhost:5150/post", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        //optionally construct query
        HttpResponseMessage response = await client.GetAsync("http://localhost:5150/post");
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync("http://localhost:5150/post/" + id);
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
        Post post = JsonSerializer.Deserialize<Post>(responseContent, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}