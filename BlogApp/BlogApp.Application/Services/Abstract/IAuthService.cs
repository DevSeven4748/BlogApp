using BlogApp.Application.DTOs;
using BlogApp.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Services.Abstract
{
    public interface IAuthService
    {
        public Result Register(RegisterRequest request);

        // public Result Login();

    }
}
