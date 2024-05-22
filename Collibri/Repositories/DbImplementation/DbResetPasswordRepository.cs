using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Collibri.Repositories.DbImplementation
{
    public class DbResetPasswordRepository
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public DbResetPasswordRepository(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<bool> SendResetPasswordEmailAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return false;
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            var encodedToken = WebUtility.UrlEncode(resetToken);
            var resetLink = $"https://localhost:44414/reset-password/{encodedToken}";

            // Simulate sending an email by printing details to the console
            Console.WriteLine($"Email: {userEmail}");
            Console.WriteLine("Subject: Collibri Password Reset");
            Console.WriteLine($"Reset Link: {resetLink}");
            
            return true;
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userEmail, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            return await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
    }
}