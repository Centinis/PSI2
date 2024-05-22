namespace Collibri.CustomExceptions
{
    public class AccountException : Exception
    {
        public string InvalidField { get; }

        public AccountException(string message, string invalidField) : base(message)
        {
            InvalidField = invalidField;
        }
    }
}
