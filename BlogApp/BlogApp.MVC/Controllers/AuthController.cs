 using BlogApp.Application.DTOs.Auth;
using BlogApp.Application.Services.Abstract;
using BlogApp.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.MVC.Controllers
{
    public class AuthController(IAuthService authService, ICookieAuthService cookieAuthService) : Controller
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

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View(model);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);

            if (!result.Success || result.Data is null)
            {
                ViewBag.ErrorMessage = result.Message;
                return View(model);
            }


            //cookie authentication
            await cookieAuthService.SignInAsync(result.Data!);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await cookieAuthService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
