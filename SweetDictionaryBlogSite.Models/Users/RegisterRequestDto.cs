

namespace SweetDictionaryBlogSite.Models.Users;

public sealed record RegisterRequestDto(
    string Name,
    string Lastname,
    string Username,
    string Email,
    DateTime BirthDate,
    string Password
    );

