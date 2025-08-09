using System;
using Blog.DTOs;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Service;

public class AuthService
{
   private readonly ILogger<AuthService> _logger;
   private readonly UserRepository _userRepository;
   private readonly JwtTokenService _jwtTokenService;

   public AuthService(ILogger<AuthService> logger, UserRepository userRepository, JwtTokenService jwtTokenService)
   {
      _logger = logger;
      _userRepository = userRepository;
      _jwtTokenService = jwtTokenService;
   }

   public async Task<User> RegisterUser(UserDto userDto)
   {
      var users = await _userRepository.CreateUser(userDto.Username, userDto.Password, userDto.Role);
      return users;
   }
   public async Task<UserResponse?> GetUsers(ResponseDto responseDto)
   {
      var user = await _userRepository.GetUserByUsername(responseDto.Username);

      if (user is null)
         throw new UnauthorizedAccessException("User Not Found");

      var isCorrectPwd = BCrypt.Net.BCrypt.Verify(responseDto.Password, user.Password);

      if (!isCorrectPwd) 
       throw new UnauthorizedAccessException("Incorect Username or Password");
     

      var jwtToken = _jwtTokenService.GenerateToken(user.Id, user.Username, user.Role);
      return new UserResponse(user.Id, user.Username, user.Role, jwtToken);
   }

}
