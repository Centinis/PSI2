using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.DbImplementation.UnitOfWork;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.DbImplementation
{
    public class DbRoomRepository : IRoomRepository
    {
        private readonly IUnitOfWork<DataContext> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        
        public DbRoomRepository(IUnitOfWork<DataContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = unitOfWork.Context;
        }
        
        public RoomDTO? CreateRoom(RoomDTO room)
        {
            room.Id = new int().GenerateNewId(_context.Rooms.Select(x => x.Id).ToList());
            room.InvitationCode = new int().GenerateNewId(_context.Rooms.Select(x => x.InvitationCode).ToList());
            
            _unitOfWork.CreateTransaction();
            
            _context.Rooms.Add(_mapper.Map<Room>(room));
            _unitOfWork.Save();
            
            _context.RoomMembers.Add(new RoomMember(room.Id, room.CreatorUsername));
            _unitOfWork.Save();
            
            _unitOfWork.Commit();
            
            return room;
        }
        
        public RoomDTO? GetRoomByCode(int code)
        {
            var roomByCode = _context.Rooms.FirstOrDefault(x => x.InvitationCode == code);

            if (roomByCode == null)
            {
                return null;
            }

            return _mapper.Map<RoomDTO>(roomByCode);
        }

        public List<RoomDTO> GetRoomsByUsername(string username)
        {
            var userRooms = 
                _context.Rooms.Where(x => _context.RoomMembers.Any(y => y.Username == username && y.RoomId == x.Id))
                              .ToList();
            
            return _mapper.Map<List<RoomDTO>>(userRooms);
        }

        public RoomDTO? UpdateRoom(int roomId, RoomDTO updatedRoom)
        {
            var roomToUpdate = _context.Rooms.FirstOrDefault(room => room.Id == roomId);

            if (roomToUpdate == null)
            {
                return null; 
            }

            roomToUpdate.Name = updatedRoom.Name;

            _context.Rooms.Update(roomToUpdate);
            _context.SaveChanges();

            return _mapper.Map<RoomDTO>(roomToUpdate);
        }

        public RoomDTO? DeleteRoom(int roomId)
        {
            var roomToRemove = _context.Rooms.FirstOrDefault(room => room.Id == roomId);
        
            if (roomToRemove == null)
            {
                return null;
            }
        
            _context.Rooms.Remove(roomToRemove);
            _context.SaveChanges();

            return _mapper.Map<RoomDTO>(roomToRemove);
        }
    }
}