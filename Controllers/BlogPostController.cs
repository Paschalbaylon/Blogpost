using System;
using Blog.DTOs;
using Blog.Models;
using Blog.Repositories;
using Blog.Service;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;

[Route("Api/[controller]")]
[ApiController]

public class BlogPostController : BaseController<BlogPostController>
{

    private readonly UserService _userService;
    private readonly BlogPostRepsitory _blogPostRepsitory;
    private readonly BlogDbContext _blogDbContext;

    public BlogPostController(ILogger<BlogPostController> logger, UserService userService, BlogDbContext blogDbContext, BlogPostRepsitory blogPostRepsitory) : base(logger)
    {
        _userService = userService;
        _blogDbContext = blogDbContext;
        _blogPostRepsitory = blogPostRepsitory;
    }

    [HttpPost("Create BlogPost")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatePosts([FromBody] BlogPostDto blogPostDto)
    {
        var posts = await _blogPostRepsitory.CreateBlogPost(blogPostDto.Tittle, blogPostDto.Content, blogPostDto.UserId);
        if (posts == null)
        {
            return BadRequest("Post Not Found");
        }
        return Ok(posts);
    }

    [HttpGet("GetAllPosts")]
    [Authorize]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _blogPostRepsitory.GetAllPost();
        return Ok(posts);
    }

    [HttpPatch("Update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePosts(int Id, [FromBody] BlogPost updatePost)
    {
        var posts = await _blogPostRepsitory.UpdatePost(Id, updatePost);
        if (posts == null)
        {
            return BadRequest("No Updated Post");
        }
        return Ok(posts);
    }

    [HttpDelete("DeletePosts/{Id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePosts([FromRoute] int Id)
    {
        await _blogPostRepsitory.DeletePost(Id);
        return Ok();
    }

    [HttpGet("GetUser-By/{UserId}")]
    [Authorize]
    public async Task<IActionResult> GetUsersId([FromRoute] int UserId)
    {
        var userId = _userService.GetUserId();
        await _blogDbContext.BlogPosts.Where(x => x.UserId == UserId).SingleOrDefaultAsync();
        return Ok(userId);
    }

    [HttpPost("PostUser/{UserId}")]
    [Authorize]
    public async Task<IActionResult> PostUserId([FromRoute] BlogPost blogPost)
    {
        var userId = _userService.GetUserId();
        blogPost.UserId = userId;
        await _blogDbContext.BlogPosts.AddAsync(blogPost);

        return CreatedAtAction(nameof(GetAllPosts), new { id = blogPost.Id }, userId);
    }
}
