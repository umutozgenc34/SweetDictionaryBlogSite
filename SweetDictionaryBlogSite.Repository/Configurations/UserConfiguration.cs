

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("UserId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Username).HasColumnName("Username");
        builder.Property(c => c.FirstName).HasColumnName("FirstName");
        builder.Property(c => c.LastName).HasColumnName("LastName");
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.Password).HasColumnName("Password");

        builder.HasMany(x => x.Posts).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
        builder.HasMany(x => x.Comments);

        builder.HasData(
            new User()
            {
                Id = 1,
                Email = "umut@gmail.com",
                FirstName = "Umut",
                LastName = "Ozgenc",
                Password = "12321321321",
                CreatedTime = DateTime.Now,
                Username = "umutozgenc34"
            });

        builder.Navigation(x => x.Posts).AutoInclude();
    }
}
