using System.ComponentModel.DataAnnotations;

namespace BlogApp.Application.DTOs.Auth
{
    public class LoginRequest
    {

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(100), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
