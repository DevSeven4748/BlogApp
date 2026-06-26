using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int CreatedByUserId { get; set; }
        public int CategoryId { get; set; }
        public BlogPostStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Category Category { get; set; } = default!;
        public virtual User User { get; set; } = default!;





    }

    public enum BlogPostStatus
    {
        Pending,
        Approved,
        Published
    }
}
