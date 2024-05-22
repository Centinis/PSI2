using Collibri.Dtos;
using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    
    [Route("/v1/documents")] // tokiu ir tokiu adresu issaugos faila.
    [ApiController]
    public class DocumentController : ControllerBase
    {
        

        private readonly IDocumentRepository _documentRepository;

        public DocumentController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }
        
        [HttpPost("{postId}")]
        public IActionResult CreateDocument([FromBody] DocumentDTO input, string postId)
        {

            var result = _documentRepository.CreateDocument(input, postId);
            return result == null? Conflict(): Ok(result);
            
        }

        [HttpGet("{postId}")]
        public IActionResult GetDocuments(string postId)
        {
            return Ok(_documentRepository.GetDocuments(postId));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDocument(int id)
        {
            var result = _documentRepository.DeleteById(id);
            return result == null ? NotFound() : Ok(result);
        }
        
        [HttpDelete("in-post")]
        public IActionResult DeleteAllDocumentsInPost([FromQuery] Guid postId)
        {
            return Ok(_documentRepository.DeleteAllDocumentsInPost(postId));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDocument([FromBody] DocumentDTO input, int id)
        {
            var result = _documentRepository.UpdateDocument(input, id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}