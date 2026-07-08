using BlogApp.Application.Services.Abstract;
using BlogApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.MVC.Controllers
{
    public class HomeController(IBlogPostService blogPostService) : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var result = await blogPostService.GetAllBlogPosts();

            if (!result.Success)
                return ViewBag.ErrorMessage = result.Message ?? "An error occured.";

            var blogPosts = result.Data;
            return View(blogPosts);
        }

    }
}
