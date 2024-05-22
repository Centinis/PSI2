using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Repositories.DbImplementation
{
    public class DbRoomMemberRepository : IRoomMemberRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public DbRoomMemberRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        
        public RoomMemberDTO? CreateRoomMember(int code, RoomMemberDTO newMember)
        {
            var roomByCode = _context.Rooms.FirstOrDefault(x => x.InvitationCode == code);
            
            if (roomByCode == null)
            {
                return null;
            }

            if (_context.RoomMembers.Any(x => x.RoomId == roomByCode.Id && x.Username == newMember.Username))
            {
                return null;
            }

            newMember.RoomId = roomByCode.Id;
            _context.RoomMembers.Add(_mapper.Map<RoomMember>(newMember));
            _context.SaveChanges();

            return newMember;
        }

        public RoomMemberDTO? DeleteRoomMember(int roomId, string username)
        {
            var memberToDelete = _context.RoomMembers.FirstOrDefault(x => x.RoomId == roomId && x.Username == username);

            if (memberToDelete == null)
            {
                return null;
            }

            _context.RoomMembers.Remove(memberToDelete);
            _context.SaveChanges();

            return _mapper.Map<RoomMemberDTO>(memberToDelete);
        }
    }   
}