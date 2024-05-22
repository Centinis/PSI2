namespace Collibri.Dtos
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public Guid PostId { get; set; }

        public DocumentDTO()
        {
            
        }
        
        public DocumentDTO(int id, Guid postId, string title, string text)
        {
            Title = title;
            Id = id;
            PostId = postId;
            Text = text;
        }
    }
}