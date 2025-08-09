using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Like
{
[Key]
public int Id { get; set; }
public int BlogPostId { get; set; }
public string UserId { get; set; }
public DateTime CreatedAt { get; set; } = DateTime.Now;

public Like(int id, int blogPostId, string userId)
{
    Id = id;
    BlogPostId = blogPostId;
    UserId = userId;
}

public BlogPost? BlogPosts{ get; set; } 
public User? Users { get; set; }
}
