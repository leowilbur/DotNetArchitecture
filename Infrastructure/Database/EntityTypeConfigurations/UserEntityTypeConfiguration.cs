using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Model.Models;

namespace Solution.Infrastructure.Database
{
    public sealed class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(x => x.UserId);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Login).IsUnique();

            builder.Property(x => x.Email).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Login).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.UserId).IsRequired().ValueGeneratedOnAdd();

            builder.HasMany(x => x.UsersLogs).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
