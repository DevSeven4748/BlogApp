using BlogApp.Application.DTOs.Auth;
using BlogApp.Application.Services.Abstract;
using BlogApp.Core.Results;
using BlogApp.Core.Security;
using BlogApp.Data;
using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BlogApp.Application.Services.Concrete
{
    public class AuthService(AppDbContext context) : IAuthService
    {
        public async Task<Result> RegisterAsync(RegisterRequest request)
        {
            //business rule
            var userExists = context.Users.Any(u => u.Email == request.Email);
            if (userExists) 
                return Result.Fail("This e-mail is already in use.");

            //hashing password
            var hashResult = HashingHelper.CreatePasswordHash(request.Password);

            //save to db
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hashResult.Hash,
                PasswordSalt = hashResult.Salt,
                IsActive = false
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Result.Ok();
        }






    }
}
