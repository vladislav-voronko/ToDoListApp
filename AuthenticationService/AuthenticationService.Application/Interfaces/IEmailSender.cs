using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Application.Interfaces;
public interface IEmailSender<TUser> where TUser : class
{
    Task SendEmailAsync(string email, string subject, string htmlMessage);
    Task SendConfirmationLinkAsync(TUser user, string email, string confirmationLink);
    Task SendPasswordResetLinkAsync(TUser user, string email, string resetLink);
    Task SendPasswordResetCodeAsync(TUser user, string email, string resetCode);
}