

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

    public async Task<string> ChangePasswordAsync(string id, ChangePasswordRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);

        var result = await _userManager.ChangePasswordAsync(user,dto.OldPassword,dto.NewPassword);
        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
        return "Şifre değiştirildi";
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

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);
        await _userManager.DeleteAsync(user);
        return "Kullanıcı silindi";
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        UserIsPresent(user);
        return user;
        
    }

    public async Task<User> LoginAsync(LoginRequestDto loginRequestDto)
    {
        var userExist = await _userManager.FindByEmailAsync(loginRequestDto.Email);
        UserIsPresent(userExist);

        var result = await _userManager.CheckPasswordAsync(userExist, loginRequestDto.Password);
        if (result is false)
        {
            throw new NotFoundException("Parola yanlış");
        }

        return userExist;
    }

    public async Task<User> UpdateAsync(string id, UpdateRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);

        user.UserName = dto.Username;
        user.BirthDate = dto.BirthDate;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
        return user;
    }

    private void UserIsPresent(User? user)
    {
        throw new NotFoundException("Kullanıcı bulunamadı");
    }
}
