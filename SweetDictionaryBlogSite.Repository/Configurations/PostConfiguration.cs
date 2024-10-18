

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("PostId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c => c.Title).HasColumnName("Title");
        builder.Property(c => c.Content).HasColumnName("Content");
        builder.Property(c => c.AuthorId).HasColumnName("AuthorId");
        builder.Property(c => c.CategoryId).HasColumnName("CategoryId");


        builder.HasOne(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(X => X.Author).WithMany(x => x.Posts).HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.NoAction);


        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x => x.Author).AutoInclude();
        builder.Navigation(x => x.Comments).AutoInclude();
    }
}
