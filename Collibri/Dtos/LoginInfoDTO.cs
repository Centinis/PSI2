using System.Runtime.Serialization;

namespace Collibri.Dtos
{
    [DataContract]
    public class LoginInfoDTO
    {
        [DataMember]
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginInfoDTO()
        {
            
        }

        public LoginInfoDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }   
}