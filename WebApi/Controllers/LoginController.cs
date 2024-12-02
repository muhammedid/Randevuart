using Business.Abstract;
using Core.Utilities.ResultCore;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }  

        [HttpGet("Login")]
        public IActionResult Login(LoginBussinesDto loginBussinesDto) 
        {
            return Ok(_authService.Login(loginBussinesDto));

        }
    }
}
