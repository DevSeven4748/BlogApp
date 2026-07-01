using System.ComponentModel.DataAnnotations;

namespace BlogApp.MVC.Models.ViewModels.AuthViewModels
{
    public class RegisterViewModel
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
