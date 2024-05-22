using System.ComponentModel.DataAnnotations;

namespace Collibri.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public Guid PostId { get; set; }
        
        public virtual Post Post { get; set; }
        
        public Document()
        {
            
        }
    }
}