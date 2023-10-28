using System.Security.Claims;
using System.Text;
using System.Text.Json;
using HTTPServices.IServices;
using Shared.DTOs;

namespace HTTPServices.Implementations;

public class PostService : IPostService
{
    private HttpClient client;
    
    public PostService(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task PostAsync(string title, string body, int authorId)
    {
        PostCreationDto postDto = new()
        {
            title = title,
            body = body,
            authorId = authorId
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
}