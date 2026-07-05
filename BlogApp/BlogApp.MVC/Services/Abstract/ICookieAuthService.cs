using BlogApp.Application.DTOs.Auth;

namespace BlogApp.MVC.Services.Abstract
{
    public interface ICookieAuthService
    {
        Task SignInAsync(LoginResponse user);
        Task SignOutAsync();
    }
}
