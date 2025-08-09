using System;
using Blog.Models;
using Blog.SiteDbContext;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories;

public class LikeRepository(BlogDbContext blogDbContext)
{
   private readonly BlogDbContext _dbContext;
   private readonly DbSet<Like> Likes = blogDbContext.Likes;

   public async Task<List<Like?>> GetAllLikes()
   {
     var likes = await _dbContext.Likes.ToListAsync();
     if (likes != null)
     Console.WriteLine($"Liked this Post."); return null;
   }

   public async Task<Like> DeleteLike(int Id)
   {
     var likes = await _dbContext.Likes.SingleOrDefaultAsync(x => x.Id == Id);
     _dbContext.Likes.Remove(likes);
     await _dbContext.SaveChangesAsync();
     return likes;
   }
}
