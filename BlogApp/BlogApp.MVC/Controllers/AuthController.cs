using BlogApp.MVC.Models.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.MVC.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View();
        }
    }
}
