using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual List<User> Users { get; set; }
    }
}
