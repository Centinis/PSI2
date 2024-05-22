using Collibri.Dtos;

namespace Collibri.Tests.Repositories.Rooms
{
    public class RoomRepositoryTestData
    {
        public static RoomDTO ValidRoom => new RoomDTO("Test RoomDTO", "User123");

        public static RoomDTO ExistingRoom => new RoomDTO("Existing RoomDTO", "User123");

        public static List<RoomDTO> RoomsExist => new List<RoomDTO>
        {
            new RoomDTO("RoomDTO 1", "User123"),
            new RoomDTO("RoomDTO 2", "User1234")
        };

        public static int ExistingRoomId => 1;

        public static int NonExistentRoomId => 3;

        public static RoomDTO UpdatedRoom => new RoomDTO("Updated RoomDTO", "User123");
    }
}
