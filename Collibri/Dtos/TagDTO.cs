namespace Collibri.Dtos;

public class TagDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public int RoomId { get; set; }
    
    public TagDTO()
    {
        
    }
    
    public TagDTO(Guid id, string name, int roomId)
    {
        Id = id;
        Name = name;
        RoomId = roomId;
    }
}