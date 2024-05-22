using Collibri.Dtos;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/member")]
    public class RoomMemberController : ControllerBase
    {
        private readonly IRoomMemberRepository _roomMemberRepository;
        
        public RoomMemberController(IRoomMemberRepository roomMemberRepository)
        {
            _roomMemberRepository = roomMemberRepository;
        }
        
        [HttpPost("")]
        public IActionResult CreateRoomMember([FromQuery] int code,[FromBody] RoomMemberDTO newMember)
        {
            var result = _roomMemberRepository.CreateRoomMember(code, newMember);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("")]
        public IActionResult DeleteRoomMember([FromQuery] int roomId, [FromQuery] string username)
        {
            var result = _roomMemberRepository.DeleteRoomMember(roomId, username);

            return result == null ? NotFound() : Ok(result);
        }
    }   
}