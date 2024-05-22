using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.FileBasedImplementation
{
    public class FbRoomRepository : IRoomRepository
    {
        private readonly IDataHandler _dataHandler;
        private readonly List<RoomDTO> _rooms;

        public FbRoomRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
            _rooms = _dataHandler.GetAllItems<RoomDTO>(ModelType.Rooms) ?? new List<RoomDTO>();
        }

        public RoomDTO CreateRoom(RoomDTO room)
        {
            room.Id = new int().GenerateNewId(_rooms.Select(x => x.Id).ToList());
            _rooms.Add(room);
            _dataHandler.PostAllItems(_rooms, ModelType.Rooms);
            return room;
        }

        public RoomDTO? GetRoomByCode(int code)
        {
            var roomList = _dataHandler.GetAllItems<RoomDTO>(ModelType.Rooms);
            var roomByCode = roomList.FirstOrDefault(x => x.InvitationCode == code);

            return roomByCode;
        }

        public List<RoomDTO> GetRoomsByUsername(string username)
        {
            return _rooms;
        }

        public RoomDTO? UpdateRoom(int roomId, RoomDTO updatedRoom)
        {
            List<RoomDTO> roomList = _dataHandler.GetAllItems<RoomDTO>(ModelType.Rooms);
            RoomDTO? existingRoom = roomList.FirstOrDefault(room => room.Id == roomId);

            if (existingRoom == null)
            {
                return null; 
            }

            existingRoom.Name = updatedRoom.Name;

            _dataHandler.PostAllItems(roomList, ModelType.Rooms);

            return existingRoom;
        }

        public RoomDTO? DeleteRoom(int roomId)
        {
            var roomToRemove = _rooms.Find(room => room.Id == roomId);
            if (roomToRemove != null)
            {
                _rooms.Remove(roomToRemove);
                _dataHandler.PostAllItems(_rooms, ModelType.Rooms);
                return roomToRemove;
            }
            return null;
        }
    }
}