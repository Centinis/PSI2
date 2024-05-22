using Microsoft.EntityFrameworkCore;

namespace Collibri.Models
{
    [PrimaryKey(nameof(RoomId), nameof(Username))]
    public class RoomMember
    {
        public int RoomId { get; set; }
        public string Username { get; set; }
        
        public virtual Room Room { get; set; }

        public RoomMember()
        {
            
        }

        public RoomMember(int roomId, string username)
        {
            RoomId = roomId;
            Username = username;
        }
    }
}
