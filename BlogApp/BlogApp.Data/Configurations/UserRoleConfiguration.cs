using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogApp.Data.Entities;

namespace BlogApp.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole> 
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.HasIndex(ur => new { ur.RoleId, ur.UserId })
                .IsUnique();

            builder.HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(u => u.User.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(r => r.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    }
}
