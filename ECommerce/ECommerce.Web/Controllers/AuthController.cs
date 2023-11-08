using ECommerce.Web.Models;
using ECommerce.Web.Service.IService;
using ECommerce.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text = SD.RoleAdmin,Value = SD.RoleAdmin},
                new SelectListItem{Text = SD.RoleCustomer,Value=SD.RoleCustomer} 
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {

            return View();
        }

    }
}
