using System;
using Blog.Models;
using Blog.Repositories;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Blog.Service;

public class UserService
{
    public int GetUserId()
    {
        return 123;
    }
}
