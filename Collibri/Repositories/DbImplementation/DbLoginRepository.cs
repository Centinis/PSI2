using Collibri.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Collibri.Repositories.DbImplementation
{   
    public class DbLoginRepository
    {
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;

        public DbLoginRepository(SignInManager<IdentityUser<Guid>> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<string?> LoggingInRequestAsync(LoginInfoDTO loginInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInfo.Username, loginInfo.Password, false, false);
            
            return result.Succeeded ? loginInfo.Username : null;
        }
    }
}