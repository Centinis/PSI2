using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/sections")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        { 
            _sectionRepository = sectionRepository;
        }

        [HttpPost("")]
        public IActionResult CreateSection([FromBody] SectionDTO section)
        {
            var result = _sectionRepository.CreateSection(section);
            return result == null ? Conflict() : Ok(result);
        }
        
        [HttpGet("")]
        public IActionResult GetAllSections([FromQuery] int roomId)
        {
            return Ok(_sectionRepository.GetAllSections(roomId));
        }

        [HttpPut("")]
        public IActionResult UpdateSectionById([FromQuery] int sectionId, [FromBody] SectionDTO section)
        {
            var updatedSection = _sectionRepository.UpdateSectionById(section, sectionId);

            return updatedSection == null ? NotFound() : Ok(updatedSection);
        }

        [HttpDelete("")]
        public IActionResult DeleteSectionById([FromQuery] int sectionId)
        {
            var deletedSection = _sectionRepository.DeleteSectionById(sectionId);

            return deletedSection == null ? NotFound() : Ok(deletedSection);
        }
    }
}
