using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Blog.SiteDbContext;

namespace Blog.Repositories;

public class UserRepository(BlogDbContext dbContext)
{
    private readonly BlogDbContext _DbContext = dbContext;

    public async Task<User> CreateUser(string Username, string Password, string Role)
    {
        var users = new User(Username, Password, Role);
        _DbContext.Users.Add(users);
        await _DbContext.SaveChangesAsync();
        return users;
    }

    public async Task<User?> GetUser(string username, string password, string role)
    {
        var user = await _DbContext.Users.FindAsync(username, password, role);
        return user;
    }
    public async Task<User?> GetUserByUsername(string username)
    {
        return await _DbContext.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
    }

    public async Task<User?> DeleteUser(int id)
    {
        var user = _DbContext.Users.SingleOrDefault(x => x.Id == id);
        _DbContext.Users.Remove(user);
        await _DbContext.SaveChangesAsync();
        return user;
    }
}
