using System.Runtime.Serialization;

namespace Collibri.Dtos
{
    [DataContract]
    public class AccountDTO
    {   
        public Guid Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDTO(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }    
}
