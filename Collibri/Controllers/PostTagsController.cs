using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/post-tags")]
    public class PostTagsController : ControllerBase
    {
        private readonly IPostTagsRepository _postTagsRepository;
        
        public PostTagsController(IPostTagsRepository postTagsRepository)
        {
            _postTagsRepository = postTagsRepository;
        }
        
        [HttpPost("")]
        public IActionResult AddToPost(Guid tagId, Guid postId)
        {
            return _postTagsRepository.AddTagToPost(tagId, postId) ? Ok() : Conflict();
        }
        
        [HttpDelete("")]
        public IActionResult RemoveFromPost(Guid tagId, Guid postId)
        {
            return _postTagsRepository.RemoveTagFromPost(tagId, postId) ? Ok() : NotFound();
        }
    }
}

