using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Comment
{
[Key]
public int Id { get; set; }
public int BlogPostId { get; set; }
[Required]
public string Content { get; set; } = string.Empty;
[Required]
public int UserId { get; set; }
public DateTime Created { get; set; } = DateTime.Now;

public Comment(int id, int blogPostId,string content, int userId)
{
    Id = id;
    BlogPostId = blogPostId;
    Content = content;
    UserId = userId;
}

public BlogPost? BlogPost { get; set; }
public User? Users { get; set; }
}
