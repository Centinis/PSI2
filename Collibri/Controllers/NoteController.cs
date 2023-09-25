﻿using Collibri.Models.Notes;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/Notes")]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpPost("")]
        public IActionResult CreateNote([FromBody] Note note)
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
        
        [HttpGet("inSection/{sectionId:int}")]
        public IActionResult GetAllNotesInSection(int sectionId)
        {
            return Ok(_noteRepository.GetAllNotesInSection(sectionId));
        }
        
        [HttpGet("inRoom/{roomId:int}")]
        public IActionResult GetAllNotesInRoom(int roomId)
        {
            return Ok(_noteRepository.GetAllNotesInRoom(roomId));
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteNote(int id)
        {
            var result = _noteRepository.DeleteNote(id);
            return result == null ? Conflict() : Ok(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateNote([FromBody] Note note, int id)
        {
            var result = _noteRepository.UpdateNote(note, id);
            return result == null ? Conflict() : Ok(result);
        }
    }
}
