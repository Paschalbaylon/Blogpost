using System;
using Blog.DTOs;
using Blog.Repositories;
using Blog.Service;
using Blog.SiteDbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[Authorize]
public class UserController : BaseController<UserController>
{
   private readonly BlogDbContext _blogDbContext;
   private readonly UserRepository _userReposiory;
   private readonly UserService _userService;

   public UserController(ILogger<UserController> logger, BlogDbContext blogDbContext, UserRepository userRepository, UserService userService) : base(logger)
   {
      _blogDbContext = blogDbContext;
      _userReposiory = userRepository;
      _userService = userService;
   }
   [HttpPost("Create A User")]
   [Authorize]
   public async Task<IActionResult> Create(UserDto userDto)
   {
      var user = await _userReposiory.CreateUser(userDto.Username, userDto.Password, userDto.Role);
      return Ok(user);
   }

   [HttpGet("all")]
   [Authorize(Roles = "Admin")]
   public async Task<IActionResult> GetUsers(UserDto userDto)
   {
      if (userDto is null)
      {
         return NotFound("User Not Found");
      }
      await _userReposiory.GetUser(userDto.Username, userDto.Password, userDto.Role);

      return Ok(userDto);
   }

   [HttpGet]
   [Authorize]
   public async Task<IActionResult> GetUsersByUsername([FromQuery] string username)
   {
      var userDto = await _userReposiory.GetUserByUsername(username);

      if (userDto is null)
      {
         return NotFound("No User was found with this Username");
      }
      return Ok(userDto);
   }

   [HttpDelete]
   [Authorize]
   public async Task<IActionResult> DeletingUser(int Id)
   {
      await _userReposiory.DeleteUser(Id);
      return Ok();
   }
}
