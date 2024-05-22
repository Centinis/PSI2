using System.ComponentModel.DataAnnotations;

namespace Collibri.Models;

public class Tag
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public int RoomId { get; set; }

    public virtual Room Room { get; set; }
    public virtual ICollection<PostTags> PostTags { get; set; }
    
    public Tag()
    {
        
    }
}