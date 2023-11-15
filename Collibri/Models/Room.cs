using System.ComponentModel.DataAnnotations;

namespace Collibri.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        
        public virtual ICollection<RoomMember> RoomMembers { get; set; }
        public virtual ICollection<Section> Sections { get; set; } 
        
        public Room()
        {
            
        }
    }
}

