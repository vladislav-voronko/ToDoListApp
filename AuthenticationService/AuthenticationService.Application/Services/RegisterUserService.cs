using Microsoft.AspNetCore.Identity;
using AuthenticationService.Application.DTOs;
using AuthenticationService.Application.Interfaces;

namespace AuthenticationService.Application.Services;
public class RegisterUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEmailSender<IdentityUser> _emailSender;

    public RegisterUserService(UserManager<IdentityUser> userManager, IEmailSender<IdentityUser> emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterUserDto dto)
    {
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"https://yourapp.com/confirm?userId={user.Id}&token={token}";
            await _emailSender.SendConfirmationLinkAsync(user, user.Email, confirmationLink);
        }
        return result;
    }
}