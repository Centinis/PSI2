using System.ComponentModel.DataAnnotations;

namespace Collibri.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public Guid PostId { get; set; }
        public string Author { get; set; } = "";
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        
        public virtual Post Post { get; set; }
        
        public Note()
        {
            
        }
    }
}
