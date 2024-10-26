

using Core.Entities;

namespace SweetDictionaryBlogSite.Models.Entities;

public sealed class Comment : Entity<Guid>
{
    public string Text { get; set; }
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
