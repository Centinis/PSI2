using Collibri.Models;

namespace Collibri.Repositories
{
    public interface IRoomRepository
    {
        public Room? CreateRoom(Room room);
        public List<Room> GetAllRooms();
        public Room? UpdateRoom(int roomId, Room updatedRoom);
        public bool DeleteRoom(int roomId);
    }
}
