

namespace SweetDictionaryBlogSite.Models.Users;

public sealed record UpdateRequestDto(
    string Username,
    DateTime BirthDate
    );

