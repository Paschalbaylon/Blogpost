using System;
using Blog.DTOs;
using Blog.Models;
using Blog.Service;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Authorize]
public class AuthController : BaseController<AuthController>
{
private readonly BlogDbContext _blogDbContext;
private readonly AuthService _authService;

public AuthController(ILogger<AuthController> logger, BlogDbContext blogDbContext, AuthService authService) : base(logger)
{
    _blogDbContext = blogDbContext;
    _authService = authService;
}

[HttpPost("Login")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]

public async Task<IActionResult> Login(UserDto userDto)
{
    var user = await _authService.RegisterUser(userDto);

    return Ok(user);
}


[HttpPost]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]

public async Task<IActionResult> Users(ResponseDto responseDto)
{
   var user = await _authService.GetUsers(responseDto);
   if (user is null)
   Console.WriteLine("No User Found"); return Ok(user);
}
}
