

using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using SweetDictionaryBlogSite.Models.Entities;
using SweetDictionaryBlogSite.Models.Users;
using SweetDictionaryBlogSite.Service.Abstracts;

namespace SweetDictionaryBlogSite.Service.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto)
    {
        User user = new User()
        {
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Username,
            BirthDate = registerRequestDto.BirthDate,
        };
        var result = await _userManager.CreateAsync(user,registerRequestDto.Password);

        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı Bulunamadı.");
        }
        return user;
        
    }
}
