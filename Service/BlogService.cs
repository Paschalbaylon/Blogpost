using System;
using Blog.DTOs;
using Blog.Models;
using Blog.Repositories;
using Blog.Util;

namespace Blog.Service;

public class BlogService
{
    private readonly ILogger<BlogService> _logger;
    private readonly BlogPostRepsitory _blogPostRepsitory;
    private readonly JwtSession _jwtSession;
    private readonly UserService _userService;

    public BlogService(ILogger<BlogService> logger, BlogPostRepsitory blogPostRepsitory, JwtSession jwtSession, UserService userService)
    {
        _logger = logger;
        _blogPostRepsitory = blogPostRepsitory;
        _jwtSession = jwtSession;
        _userService = userService;
    }
    public async Task<BlogPost> CreateBlog(BlogPostDto blogPostDto)
    {
        var creatorId = int.Parse(_jwtSession.UserId ??
                    throw new UnauthorizedAccessException("Sorry you don't have access to this page"));

        var blog = await _blogPostRepsitory.CreateBlogPost(blogPostDto.Tittle, blogPostDto.Content, creatorId);
        return blog;
    }
}
