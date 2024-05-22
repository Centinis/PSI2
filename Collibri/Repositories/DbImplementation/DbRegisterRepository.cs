using Collibri.CustomExceptions;
using Collibri.Dtos;
using Collibri.Repositories.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace Collibri.Repositories.DbImplementation
{
    public class DbRegisterRepository
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public DbRegisterRepository(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<AccountDTO?> CreateAccountAsync(AccountDTO account)
        {
            var user = new IdentityUser<Guid> { UserName = account.Username, Email = account.Email};

            try
            {
                user.Email.IsValidEmail();
            }
            catch (AccountException ex)
            {
                Log.Error(ex, "Error setting email: {ErrorMessage}, Invalid Field: {InvalidField}", ex.Message,
                    ex.InvalidField);

                return null;
            }
            
            var result = await _userManager.CreateAsync(user, account.Password);
            return result.Succeeded ? account : null;
        }
        
        // public Account? CreateAccount(Account account)
        // {
        //     
        //     // var createAccountTask = _registerTasks.CreateAccountAsync();
        //     var createAccountAsync = CreateAccountAsync();
        //     createAccountAsync.Start();
        //     
        //     
        //     return null;
        // }
        
        // private readonly DataContext _context;
        //
        // public DbRegisterRepository(DataContext dataContext)
        // {
        //     _context = dataContext;
        // }
        //
        // public List<Account> GetAllAccounts()
        // {
        //     return _context.Accounts.ToList();
        // }
        //
        // public Account? UpdateAccount(string username, Account updatedAccount)
        // {
        //     var accountToUpdate = _context.Accounts.FirstOrDefault(account => account.Username == username);
        //
        //     if (accountToUpdate == null)
        //     {
        //         return null;
        //     }
        //     
        //     accountToUpdate.Username = updatedAccount.Username;
        //     accountToUpdate.Email = updatedAccount.Email;
        //     accountToUpdate.Password = updatedAccount.Password;
        //
        //     _context.Accounts.Update(accountToUpdate);
        //     _context.SaveChanges();
        //     
        //     return accountToUpdate;
        // }
        //
        // public bool DeleteAccount(string username)
        // {
        //     var accountToRemove = _context.Accounts.FirstOrDefault(account => account.Username == username);
        //
        //     if (accountToRemove == null)
        //         return false;
        //
        //     _context.Accounts.Remove(accountToRemove);
        //     _context.SaveChanges();
        //
        //     return true;
        // }
    }
}
