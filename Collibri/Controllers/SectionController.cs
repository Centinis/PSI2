using Collibri.Models.Sections;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/rooms/{roomName}/sections")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        { 
            _sectionRepository = sectionRepository;
        }

        [HttpPost("")]
        public IActionResult CreateSection([FromBody] Section section, string roomName)
        {
            var result = _sectionRepository.CreateSection(section, roomName);
            return result == null ? Conflict() : Ok(result);
        }
        
        [HttpGet("")]
        public IActionResult GetAllSections([FromBody] int roomId, string roomName)
        {
            return Ok(_sectionRepository.GetAllSections(roomId, roomName));
        }
    }
}
