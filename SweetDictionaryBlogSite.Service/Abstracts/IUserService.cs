
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Users;

namespace SweetDictionaryBlogSite.Service.Abstracts;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);
    Task<User> LoginAsync(LoginRequestDto loginRequestDto);
    Task<string> DeleteAsync(string id);
    Task<User> UpdateAsync(string id , UpdateRequestDto dto);
    Task<string> ChangePasswordAsync(string id , ChangePasswordRequestDto dto);

}
