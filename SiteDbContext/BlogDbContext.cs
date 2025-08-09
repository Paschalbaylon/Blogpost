using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.SiteDbContext;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) 
    : base(options){}

    public DbSet<BlogPost> BlogPosts{ get; set; }
    public DbSet<Comment> Comments{ get; set; }
    public DbSet<Like> Likes{ get; set; }
    public DbSet<User> Users { get; set; }
}
