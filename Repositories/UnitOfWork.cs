using System;
using Blog.SiteDbContext;

namespace Blog.Repositories;

public class UnitOfWork(BlogDbContext dbContext)
{
    private readonly BlogDbContext _DbContext = dbContext;

    public async Task SaveChangesAsync()
    {
        await _DbContext.SaveChangesAsync();
    }
}
