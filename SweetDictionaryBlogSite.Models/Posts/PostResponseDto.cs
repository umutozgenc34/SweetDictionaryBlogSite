
namespace SweetDictionaryBlogSite.Models.Posts;
public sealed record PostResponseDto { 
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public string AuthorFirstName { get; init; }
        public string CategoryName { get; init; }
};
