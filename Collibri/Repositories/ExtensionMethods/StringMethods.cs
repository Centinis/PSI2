using System.Text.RegularExpressions;
using Collibri.CustomExceptions;

namespace Collibri.Repositories.ExtensionMethods
{
    public static class StringMethods
    {
        public static void IsValidEmail(this string email)
        {
            const string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                throw new AccountException("Invalid email address", nameof(email));
            }
        }
    }   
}