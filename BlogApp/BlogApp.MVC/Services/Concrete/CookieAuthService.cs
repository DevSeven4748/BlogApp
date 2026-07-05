using BlogApp.Application.DTOs.Auth;
using BlogApp.MVC.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace BlogApp.MVC.Services.Concrete
{
    public class CookieAuthService(IHttpContextAccessor httpContextAccessor) : ICookieAuthService
    {
        public async Task SignInAsync(LoginResponse user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new(ClaimTypes.Email, user.Email),
                new("IsActive", user.IsActive.ToString())
            };
            
            if(user.Roles != null) 
            { 
                foreach(var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(claimsIdentity);

            var httpcontext = httpContextAccessor.HttpContext;
            
            if(httpcontext != null)
            {
                await httpcontext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }

        }

        public async Task SignOutAsync()
        {
            var httpcontext = httpContextAccessor.HttpContext;
            if(httpcontext != null)
            { 
                await httpcontext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }



    }
}

