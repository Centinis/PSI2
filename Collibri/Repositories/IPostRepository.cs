using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface IPostRepository
    {
        public PostDTO CreatePost(PostDTO post);

        public IEnumerable<PostDTO> GetAllPosts(int sectionId);

        public PostDTO? UpdatePostById(Guid postId, PostDTO post);

        public PostDTO? DeletePostById(Guid postId);
    }
}