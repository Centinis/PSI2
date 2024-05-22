using Microsoft.EntityFrameworkCore;

namespace Collibri.Models
{
    [Keyless]
    public class PostTags
    {   
        public Guid TagId { get; set; }
        public Guid PostId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Post Post { get; set; }
    }
}

