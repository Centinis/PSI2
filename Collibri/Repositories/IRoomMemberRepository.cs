using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface IRoomMemberRepository
    {
        public RoomMemberDTO? CreateRoomMember(int code, RoomMemberDTO newMember);
        public RoomMemberDTO? DeleteRoomMember(int roomId, string username);
    }   
}