namespace Collibri.Dtos
{
    public class SectionDTO : IEquatable<SectionDTO>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string SectionName { get; set; } = "";

        public SectionDTO()
        {
            
        }
        
        public SectionDTO(int id, int roomId, string sectionName)
        {
            Id = id;
            RoomId = roomId;
            SectionName = sectionName;
        }

        public bool Equals(SectionDTO? other)
        {
            if (other == null)
            {
                return false;
            }
        
            return this.RoomId.Equals(other.RoomId) && this.SectionName.Equals(other.SectionName);
        }
    }   
}