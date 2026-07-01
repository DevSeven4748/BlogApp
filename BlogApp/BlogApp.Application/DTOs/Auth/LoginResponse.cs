using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.DTOs.Auth
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string FirtName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public List<string> Roles { get; set; } = default!;
    }
}
