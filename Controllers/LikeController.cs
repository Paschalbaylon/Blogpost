using System;
using Blog.Models;
using Blog.Repositories;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Authorize]
public class LikeController : BaseController<LikeController>
{
    private readonly BlogDbContext _blogDbContext;
    private readonly LikeRepository _likeRepository;

    public LikeController(ILogger<LikeController> logger, BlogDbContext blogDbContext, LikeRepository likeRepository) : base(logger)
    {
        _blogDbContext = blogDbContext;
        _likeRepository = likeRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> AllLikes()
    {
        var likes = await _likeRepository.GetAllLikes();

        return Ok(likes);
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteLikes([FromRoute] int Id)
    {
        var likes = await _likeRepository.DeleteLike(Id);

        return Ok(likes);
    }
}
