namespace Collibri.Dtos
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public string CreatorUsername { get; set; } = "";
        public string Title { get; set; } = "";
        public int SectionId { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public PostDTO()
        {
            
        }
        
        public PostDTO(
            Guid postId, 
            string creatorUsername, 
            string title, 
            int sectionId,
            int likeCount, 
            int dislikeCount, 
            string description, 
            DateTime creationDate, 
            DateTime lastUpdatedDate)
        {
            Id = postId;
            CreatorUsername = creatorUsername;
            Title = title;
            SectionId = sectionId;
            LikeCount = likeCount;
            DislikeCount = dislikeCount;
            Description = description;
            CreationDate = creationDate;
            LastUpdatedDate = lastUpdatedDate;
        }
    }
}

