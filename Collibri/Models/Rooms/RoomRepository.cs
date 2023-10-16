using Collibri.Models.DataHandling;

namespace Collibri.Models.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IDataHandler _dataHandler;
        private readonly List<Room> _rooms;

        public RoomRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
            _rooms = _dataHandler.GetAllItems<Room>(ModelType.Rooms) ?? new List<Room>();
        }

        public Room CreateRoom(Room room)
        {
            room.Id = new Random().Next(1, int.MaxValue);
            _rooms.Add(room);
            _dataHandler.PostAllItems(_rooms, ModelType.Rooms);
            return room;
        }

        public List<Room> GetAllRooms()
        {
            return _rooms;
        }

        public Room? UpdateRoom(int roomId, Room updatedRoom)
        {
            List<Room> roomList = _dataHandler.GetAllItems<Room>(ModelType.Rooms);
            Room? existingRoom = roomList.FirstOrDefault(room => room.Id == roomId);

            if (existingRoom == null)
            {
                return null; 
            }

            existingRoom.Name = updatedRoom.Name;

            _dataHandler.PostAllItems(roomList, ModelType.Rooms);

            return existingRoom;
        }

        public bool DeleteRoom(int roomId)
        {
            var roomToRemove = _rooms.Find(room => room.Id == roomId);
            if (roomToRemove != null)
            {
                _rooms.Remove(roomToRemove);
                _dataHandler.PostAllItems(_rooms, ModelType.Rooms);
                return true;
            }
            return false;
        }
    }
}