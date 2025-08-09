using System;
using System.Collections;
using Blog.Models;
using Blog.SiteDbContext;
using Blog.Validation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class CommentRepository(BlogDbContext blogDbContext)
{
  private readonly BlogDbContext _blogDbContext = blogDbContext;
  private readonly DbSet<BlogPost> _BlogPosts = blogDbContext.BlogPosts;
  private readonly DbSet<Comment> _Comments = blogDbContext.Comments;

  public async Task<Comment> PostComments(int Id, int BlogpostId, string Content, int UserId)
  {
    var comments = new Comment(Id, BlogpostId, Content, UserId);
    _blogDbContext.Add(comments);
    await _blogDbContext.SaveChangesAsync();
    return comments;
  }

  public async Task<List<Comment>> GetAllComments()
  {
    var blogComment = await _blogDbContext.Comments.ToListAsync();
    if (blogComment == null)
    {
      Console.WriteLine("No Comments");
    }
    return blogComment;
  }

  public async Task<Comment?> GetCommentById(int Id)
  {
    var comment = await _blogDbContext.Comments.SingleOrDefaultAsync(c => c.Id == Id);
    if (comment == null)
    {
      Console.WriteLine($"No Comment {Id} was found.");
    }
    return comment;
  }

  public async Task<Comment?> DeleteComment(int Id)
  {
    var blogComment = await _blogDbContext.Comments.SingleOrDefaultAsync(x => x.Id == Id);
    _blogDbContext.Comments.Remove(blogComment);
    await _blogDbContext.SaveChangesAsync();

    if (blogComment is null)
    {
      Console.WriteLine($"Deleted {Id}");
    }
    return blogComment;
  }

  public async Task<Comment?> GetCommentRequest(string Content)
  {
    return await _blogDbContext.Comments.Where(c => c.Content == Content).FirstOrDefaultAsync();
  }
}
