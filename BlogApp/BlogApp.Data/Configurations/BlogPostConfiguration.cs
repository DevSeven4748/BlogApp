using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogApp.Data.Entities;

namespace BlogApp.Data.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(bp => bp.Id);

            builder.Property(bp => bp.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(bp => bp.Content)
                .IsRequired();

            builder.Property(bp => bp.Status)
                .IsRequired()
                .HasDefaultValue(BlogPostStatus.Pending);

            builder.Property(bp => bp.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasOne(c => c.Category)
                .WithMany(bp => bp.Posts)
                .HasForeignKey(bp => bp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Author)
                .WithMany(bp => bp.Posts)
                .HasForeignKey(bp => bp.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
