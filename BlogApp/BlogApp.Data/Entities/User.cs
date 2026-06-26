using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public bool IsActive { get; set; } = false;

        public virtual List<UserRole> UserRoles { get; set; } = default!;
        public virtual List<BlogPost> Posts { get; set; } = default!;
    }
}
