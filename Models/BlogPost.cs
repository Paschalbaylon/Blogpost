using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class BlogPost
{
[Key]
public int Id { get; set; } = 0;
[Required]
[MaxLength(100), MinLength(10)]
public string Tittle { get; set; } = string.Empty;
[Required]
public string Content { get; set; } = string.Empty;
[Required]
public int UserId { get; set; } 
public DateTime CreatedAt { get; set; }

public BlogPost(string tittle, string content, int userId)
{
    Tittle = tittle;
    Content = content;
    UserId = userId;
}

public void UpdatePost (string tittle, string content)
{
    Tittle = tittle;
    Content = content;
}

public ICollection<Comment> comments { get; set; } = new List<Comment>();
public ICollection<Like> likes { get; set; } = new List<Like>();
public User? Users { get; set; }
}
