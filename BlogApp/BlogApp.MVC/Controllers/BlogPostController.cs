using Microsoft.AspNetCore.Mvc;

namespace BlogApp.MVC.Controllers
{
    public class BlogPostController : Controller
    {
        public IActionResult Content(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBlogPostRequest model)
        {
            return View();
        }
    }
}
