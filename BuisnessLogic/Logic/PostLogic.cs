﻿using Shared.DTOs;
using Shared.Models;
using Validation.IDaos;
using Validation.ILogic;

namespace Validation.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    
    public PostLogic(IPostDao dao)
    {
        this.postDao = dao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        Post toCreate = new Post
        {
            title = dto.title,
            body = dto.body,
            authorId = dto.authorId,
            authorUsername = dto.authorUsername
        };
    
        Post created = await postDao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync()
    {
        return postDao.GetAsync();
    }

    public Task<Post> GetByIdAsync(int id)
    {
        return postDao.GetByIsAsync(id);
    }
}