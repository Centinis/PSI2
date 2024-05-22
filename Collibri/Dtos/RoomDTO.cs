namespace Collibri.Dtos
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public int InvitationCode { get; set; }
        public string Name { get; set; } = "";
        public string CreatorUsername { get; set; }

        public RoomDTO()
        {
            
        }
        
        public RoomDTO(string name, string creatorUsername)
        {
            Name = name;
            CreatorUsername = creatorUsername;
        }
    }
}