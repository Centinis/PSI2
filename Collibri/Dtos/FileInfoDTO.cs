namespace Collibri.Dtos
{
    public class FileInfoDTO
    {
        public Guid Id { get; set; }
		
        public Guid PostId { get; set; }

        public string Path { get; set; } = "";
		
        public string Name { get; set; } = "";

        public string ContentType { get; set; } = "";

        public long Lenght { get; set; }

        public FileInfoDTO()
        {
            
        }
        
        public FileInfoDTO(Guid id, Guid postId, string path, string name, string contentType, long lenght)
        {
            Id = id;
            PostId = postId;
            Path = path;
            Name = name;
            ContentType = contentType;
            Lenght = lenght;
        }
    }
}