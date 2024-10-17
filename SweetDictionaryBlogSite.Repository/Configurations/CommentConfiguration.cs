

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SweetDictionaryBlogSite.Models.Entities;

namespace SweetDictionaryBlogSite.Repository.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("CommentId");
        builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
        builder.Property(c => c.UpdatedTime).HasColumnName("UpdatedTime");
        builder.Property(c=>c.Text).HasColumnName("Text");
        builder.Property(c=>c.AuthorId).HasColumnName("AuthorId");
        builder.Property(c => c.PostId).HasColumnName("PostId");

        builder.HasOne(x => x.Author).WithMany(x=> x.Comments).HasForeignKey(x=> x.AuthorId);
        builder.HasOne(x => x.Post).WithMany(x=> x.Comments).HasForeignKey(x=> x.PostId);
            

    }
}
