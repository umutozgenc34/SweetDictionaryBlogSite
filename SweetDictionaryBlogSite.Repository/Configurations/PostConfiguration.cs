

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PostId");
        builder.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(p => p.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(p=> p.Title).HasColumnName("Title");
        builder.Property(p => p.Content).HasColumnName("Content");
        builder.Property(p => p.AuthorId).HasColumnName("AuthorId");
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId");

        builder.HasOne(x => x.Category);
        builder.HasOne(x => x.Author).WithMany(x=> x.Posts).HasForeignKey(x=>x.AuthorId);
        builder.HasMany(x=> x.Comments);

        builder.Navigation(x => x.Category).AutoInclude();
        builder.Navigation(x=>x.Author).AutoInclude();
        builder.Navigation(x=>x.Comments).AutoInclude();
    }
}
