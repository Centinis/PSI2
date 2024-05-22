using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpPost("")]
        public IActionResult CreateNote([FromBody] NoteDTO note)
        {
            var result =  _noteRepository.CreateNote(note);
            return result == null ? Conflict() : Ok(result);
        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetNote(int id)
        {
            var result = _noteRepository.GetNote(id);
            return result == null ? Conflict() : Ok(result);
        }
        
        [HttpGet("")]
        public IActionResult GetAllNotesPost([FromQuery] Guid postId)
        {
            return Ok(_noteRepository.GetAllNotesByPost(postId));
        }
        
        //
        // [HttpGet("inRoom/{roomId:int}")]
        // public IActionResult GetAllNotesInRoom(int roomId)
        // {
        //     return Ok(_noteRepository.GetAllNotesInRoom(roomId));
        // }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteNote(int id)
        {
            var result = _noteRepository.DeleteNote(id);
            return result == null ? Conflict() : Ok(result);
        }
        
        [HttpDelete("in-post")]
        public IActionResult DeleteAllNotesInPost([FromQuery] Guid postId)
        {
            return Ok(_noteRepository.DeleteAllNotesInPost(postId));
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateNote([FromBody] NoteDTO note, int id)
        {
            var result = _noteRepository.UpdateNote(note, id);
            return result == null ? Conflict() : Ok(result);
        }
    }
}
