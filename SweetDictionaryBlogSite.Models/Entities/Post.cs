
using Core.Entities;
using System.Reflection.Metadata;

namespace SweetDictionaryBlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{
    public string Title { get; set; }
    public string Content { get; set; }
}
