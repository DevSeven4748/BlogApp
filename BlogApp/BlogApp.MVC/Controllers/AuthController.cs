using BlogApp.Application.DTOs.Auth;
using BlogApp.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.MVC.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.RegisterAsync(model);

            if(!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
