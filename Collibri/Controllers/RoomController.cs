using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [Route("/v1/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost("")]
        public IActionResult CreateRoom([FromBody] RoomDTO room)
        {
            var result = _roomRepository.CreateRoom(room);
            return result == null ? Conflict() : Ok(result);
        }

        [HttpGet("")]
        public IActionResult GetAllRoomsByUsername([FromQuery] string username)
        {
            var rooms = _roomRepository.GetRoomsByUsername(username);
            
            return rooms.Count == 0 ? NoContent() : Ok(rooms);
        }

        [HttpPut("{roomId}")]
        public IActionResult UpdateRoom(int roomId, [FromBody] RoomDTO updatedRoom)
        {
            var result = _roomRepository.UpdateRoom(roomId, updatedRoom);
    
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{roomId}")]
        public IActionResult DeleteRoom(int roomId)
        {
            var deleted = _roomRepository.DeleteRoom(roomId);
            return deleted ? NoContent() : NotFound();
        }
    }
}

