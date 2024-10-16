
namespace SweetDictionaryBlogSite.Models.Posts;

public sealed record UpdatePostRequestDto(Guid Id,string Title, string Content);
