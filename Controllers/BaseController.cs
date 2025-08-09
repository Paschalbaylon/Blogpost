using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers;

[ApiController]
[Route("[Controller]")]
public abstract class BaseController<T> : Controller where T : class 
{
   protected readonly ILogger<T> _logger;
   protected BaseController(ILogger<T> logger)
   {
    _logger = logger;
   }
}
