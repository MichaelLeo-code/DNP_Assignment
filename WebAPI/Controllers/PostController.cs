using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Models;
using Validation.ILogic;
using Validation.Logic;

namespace WebAPI.Controllers;

[ApiController]
[Route("post")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;
    
    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(PostCreationDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}