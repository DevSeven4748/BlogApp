using BlogApp.Application.DTOs.Auth;
using BlogApp.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Services.Abstract
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(RegisterRequest request);

        Task<Result<LoginResponse>> LoginAsync(LoginRequest request);

    }
}
