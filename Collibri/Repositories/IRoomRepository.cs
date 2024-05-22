using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface IRoomRepository
    {
        public RoomDTO? CreateRoom(RoomDTO room);
        public RoomDTO? GetRoomByCode(int code);
        public List<RoomDTO> GetRoomsByUsername(string username);
        public RoomDTO? UpdateRoom(int roomId, RoomDTO updatedRoom);
        public RoomDTO? DeleteRoom(int roomId);
    }
}

