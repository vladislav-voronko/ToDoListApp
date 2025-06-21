using Microsoft.AspNetCore.Identity;

namespace AuthService.Services;

public class DummyEmailSender : IEmailSender<IdentityUser>
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine($"[EmailSender] To: {email}, Subject: {subject}, Body: {htmlMessage}");
        return Task.CompletedTask;
    }

    public Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
    {
        Console.WriteLine($"[EmailSender] Confirmation link for {email}: {confirmationLink}");
        return Task.CompletedTask;
    }

    public Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
    {
        Console.WriteLine($"[EmailSender] Password reset link for {email}: {resetLink}");
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
    {
        Console.WriteLine($"[EmailSender] Password reset code for {email}: {resetCode}");
        return Task.CompletedTask;
    }
}