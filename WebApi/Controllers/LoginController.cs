using Business.Abstract;
using Core.Utilities.ResultCore;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class LoginController : Controller
    {
        IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginBussinesDto loginBussinesDto) 
        {

            return (IActionResult)_authService.Login(loginBussinesDto);
        }
    }
}
