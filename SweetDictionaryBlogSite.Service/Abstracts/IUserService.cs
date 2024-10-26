
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Users;

namespace SweetDictionaryBlogSite.Service.Abstracts;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);

}
