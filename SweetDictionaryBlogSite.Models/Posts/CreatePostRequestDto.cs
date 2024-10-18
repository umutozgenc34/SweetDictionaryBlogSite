
namespace SweetDictionaryBlogSite.Models.Posts;

public sealed record CreatePostRequestDto(string Title,string Content, int CategoryId,long AuthorId);
