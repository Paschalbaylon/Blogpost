using System;
using System.Security.Claims;
using Blog.Service;

namespace Blog.Util;

public class JwtSession
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public JwtSession(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    //Get User ID from the current context claims
    public string? UserId =>
         _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    // Get Username from the current context claims
    public string? Username =>
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

    // Get Role from the current context claims
        public string? Role =>
        _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
}
