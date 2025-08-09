using System;

namespace Blog.Models;

public class User
{
  public int Id { get; set; } = 0;
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public string Role { get; set; } = string.Empty ;

  public User(string username, string password, string role)
  {
    Username = username;
    Password = BCrypt.Net.BCrypt.HashPassword(password);
    Role = role;
  }
 public ICollection<BlogPost>? BlogPosts { get; set; }
}
