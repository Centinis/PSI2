namespace Collibri.Dtos
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public Guid PostId { get; set; }
        public string Author { get; set; } = "";
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public NoteDTO()
        {
            
        }
        
        public NoteDTO(Guid postId, string name, string text, string author, int id = 0)
        {
            this.Author = author;
            this.Name = name;
            this.Text = text;
            this.PostId = postId;
            this.Id = id;
        }
    }
}