using Collibri.Dtos;
using Collibri.Repositories.DbImplementation;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/resetPassword")]
    public class ResetPasswordController : Controller
    {
        private readonly DbResetPasswordRepository _resetPasswordRepository;

        public ResetPasswordController(DbResetPasswordRepository resetPasswordRepository)
        {
            _resetPasswordRepository = resetPasswordRepository;
        }

        [HttpPost("sendEmail")]
        public async Task<IActionResult> SendResetPasswordEmail([FromBody] SendEmailDTO email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body");
            }

            string userEmail = email.Email;
            
            var userExists = await _resetPasswordRepository.SendResetPasswordEmailAsync(userEmail);

            if (userExists)
            {
                return Ok("Reset password email sent successfully");
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body");
            }

            var result = await _resetPasswordRepository.ResetPasswordAsync(
                resetPasswordData.Email,
                resetPasswordData.Token,
                resetPasswordData.NewPassword);

            if (result.Succeeded)
            {
                return Ok("Password reset successfully");
            }
            else
            {
                return BadRequest("Password reset failed");
            }
        }
    }
}