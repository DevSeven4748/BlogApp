using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        //refactor into fluent validation library
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
