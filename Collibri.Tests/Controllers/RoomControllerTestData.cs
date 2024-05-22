using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class RoomControllerTestData
    {
        public static RoomDTO ValidRoom => new RoomDTO("TestRoom", "User1");

        public static RoomDTO ExistingRoom => new RoomDTO("TestRoom", "User1");

        public static List<RoomDTO> RoomsExist => new List<RoomDTO>
        {
            new RoomDTO("Room1", "User1"),
            new RoomDTO("Room2", "User2")
        };

        public static int ExistingRoomId => 1;

        public static int NonExistentRoomId => 3;

        public static RoomDTO UpdatedRoom => new RoomDTO("UpdatedRoom", "User1");
    }
}