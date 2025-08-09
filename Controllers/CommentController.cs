using System;
using Blog.Models;
using Blog.Repositories;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Authorize]
public class CommentController : BaseController<CommentController>
{
   private readonly BlogDbContext _blogDbContext;
   private readonly CommentRepository _commentRepository;

   public CommentController(ILogger<CommentController> logger, BlogDbContext blogDbContext, CommentRepository commentRepository) : base(logger)
   {
      _blogDbContext = blogDbContext;
      _commentRepository = commentRepository;
   }

   [HttpGet]
   [Authorize]

   public async Task<IActionResult?> CommentRequest([FromQuery] string Content)
   {
      var comment = await _commentRepository.GetCommentRequest(Content);

      return Ok(comment);
   }

   [HttpGet("all")]
   [Authorize(Roles = "Admin")]
   public async Task<IActionResult> AllComments()
   {
      var comments = await _commentRepository.GetAllComments();
      if (comments != null)

         Console.WriteLine($"No Comment"); return Ok(comments);
   }

   [HttpGet("{Id}")]
   [Authorize]
   public async Task<IActionResult> CommentsById([FromRoute] int Id)
   {
      var comments = await _commentRepository.GetCommentById(Id);
      return Ok(comments);
   }

   [HttpPost]
   [Authorize(Roles = "Admin")]
   public async Task<IActionResult> CreateComments(Comment comment)
   {
      var comments = await _commentRepository.PostComments(comment.Id, comment.BlogPostId, comment.Content, comment.UserId);

      return Ok(comments);
   }

   [HttpDelete("{Id}")]
   [Authorize(Roles = "Admin")]
   public async Task<IActionResult> DeleteComments([FromRoute] int Id)
   {
      var comments = await _commentRepository.DeleteComment(Id);
      if (comments != null)
         Console.WriteLine($"Deleted Comment {Id}"); return Ok(comments);
   }
}
