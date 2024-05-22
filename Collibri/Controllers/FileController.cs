using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost("{postId}")]
        public IActionResult CreateFile([FromForm] IFormFile file, string postId)
        {
            var result = _fileRepository.CreateFile(file, postId);
            return result == null ? Conflict("File with this name already exists") : Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFile(string id)
        {
            var result = _fileRepository.DeleteFile(id);
            return result == null ? Conflict("File does not exist") : Ok(result);
        }
	    
        [HttpGet("info/{postId}")]
        public IActionResult GetAllFiles(string postId)
        {
            var result = _fileRepository.GetAllFiles(postId);
            return result == null ? Conflict("Files do not exist") : Ok(result);
        }
        
        [HttpGet("data/{id}")]
        public FileStreamResult? GetFile(string id)
        {
            return _fileRepository.GetFile(id);
        }

        [HttpPut("{id}/{updatedName}")]
        public IActionResult UpdateFileName(string id, string updatedName)
        {
            var result = _fileRepository.UpdateFileName(id, updatedName);
            return result == null ? Conflict("File does not exist") : Ok(result);
        }
    }
}