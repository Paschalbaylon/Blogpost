using System;
using Blog.Models;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class BlogPostRepsitory(BlogDbContext dbContext)
{
    private readonly BlogDbContext _DbContext = dbContext;
    private readonly DbSet<BlogPost> _BlogPosts = dbContext.BlogPosts;
    public async Task<BlogPost> CreateBlogPost(string tittle, string content, int userId)
    {
        var blogPost = new BlogPost(tittle, content, userId);
        _DbContext.BlogPosts.Add(blogPost);
        await _DbContext.SaveChangesAsync();
        return blogPost;
    }

    public async Task<List<BlogPost>> GetAllPost()
    {
        var blog = await _DbContext.BlogPosts.ToListAsync();
        if (blog is null)
        {
            Console.WriteLine("No post Found");
        }
        return blog;
    }

    public async Task<BlogPost?> GetPostById(int id)
    {
        return await _DbContext.BlogPosts.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BlogPost?> UpdatePost(int id, BlogPost UpdatePost)
    {
        var blog = _DbContext.BlogPosts.FirstOrDefault(x => x.Id == id);
        await _DbContext.SaveChangesAsync();

        if (blog != null)
        {
            blog.Tittle = UpdatePost.Tittle;
            blog.Content = UpdatePost.Content;

            return blog;
        }
        Console.WriteLine("No Updated Post", id);
        return null;
    }

    public async Task<BlogPost?> DeletePost(int id)
    {
        var blog = _DbContext.BlogPosts.SingleOrDefault(x => x.Id == id);
        _DbContext.BlogPosts.Remove(blog);
        await _DbContext.SaveChangesAsync();

        if (blog != null)
        {
            return blog;
        }
        Console.WriteLine($"Deleted Post {id}"); return null;
    }
}
