
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace SweetDictionaryBlogSite.Models.Entities;

public sealed class User : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
}
