using BlogApp.Application.DTOs;
using BlogApp.Application.Services.Abstract;
using BlogApp.Core.Results;
using BlogApp.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Services.Concrete
{
    public class AuthService(AppDbContext context) : IAuthService
    {
        public Result Register(RegisterRequest request)
        {
            var userExists = context.Users.Any(u => u.Email == request.Email);
            if (userExists) 
                return Result.Fail("This e-mail is already in use.");
        



            return Result.Ok();
        }






    }
}
