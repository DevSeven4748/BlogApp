using BlogApp.Application.DTOs.Blog;
using BlogApp.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.MVC.Controllers
{
    public class BlogPostController(IBlogPostService blogPostService) : Controller
    {
        public async Task<IActionResult> Content(int id)
        {
            var result = await blogPostService.GetBlogPostById(id);

            if (!result.Success || result.Data is null)
                return RedirectToAction("Index", "Home");

            var post = result.Data;

            return View(post);
        }

        [Authorize]
        public IActionResult Create()
        {
            //TODO: Fill the model with categories and other necessary data for the view
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateBlogPostRequest model)
        {
            //TODO: Handle the creation of the blog post using the blogPostService.Get UserId from logged in user claims.
            return View();
        }
    }
}
