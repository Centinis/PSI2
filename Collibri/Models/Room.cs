using System.ComponentModel.DataAnnotations;

namespace Collibri.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int InvitationCode { get; set; }
        public string CreatorUsername { get; set; }
        public string Name { get; set; } = "";
        
        public virtual ICollection<RoomMember> RoomMembers { get; set; }
        public virtual ICollection<Section> Sections { get; set; } 
        public virtual ICollection<Tag> Tags { get; set; }
        
        public Room()
        {
            
        }
    }
}

