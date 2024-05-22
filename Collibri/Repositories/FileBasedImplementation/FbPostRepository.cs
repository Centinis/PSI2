using Collibri.Dtos;
using Collibri.Repositories.DataHandling;

namespace Collibri.Repositories.FileBasedImplementation
{
    public class FbPostRepository : IPostRepository
    {
        private readonly IDataHandler _dataHandler;
        
        public FbPostRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public PostDTO CreatePost(PostDTO post)
        {
            var postList = _dataHandler.GetAllItems<PostDTO>(ModelType.Posts);

            post.Id = Guid.NewGuid();
            post.CreationDate = DateTime.Now;
            post.LastUpdatedDate = DateTime.Now;
            postList.Add(post);
            
            _dataHandler.PostAllItems(postList, ModelType.Posts);
            
            return post;
        }

        public IEnumerable<PostDTO> GetAllPosts(int sectionId)
        {
            var postList = _dataHandler.GetAllItems<PostDTO>(ModelType.Posts);
            var queriedPosts = postList.Where(x => x.SectionId == sectionId);

            return queriedPosts;
        }

        public PostDTO? UpdatePostById(Guid postId, PostDTO post)
        {
            var postList = _dataHandler.GetAllItems<PostDTO>(ModelType.Posts);
            var postToUpdate = postList.SingleOrDefault(x => x.Id == postId);
            
            if (postToUpdate == null)
            {
                return null;
            }

            postToUpdate.LikeCount = post.LikeCount;
            postToUpdate.DislikeCount = post.DislikeCount;
            postToUpdate.Title = post.Title;
            postToUpdate.LastUpdatedDate = DateTime.Now;
            _dataHandler.PostAllItems(postList, ModelType.Posts);

            return postToUpdate;
        }

        public PostDTO? DeletePostById(Guid postId)
        {
            var postList = _dataHandler.GetAllItems<PostDTO>(ModelType.Posts);
            var postToDelete = postList.SingleOrDefault(x => x.Id == postId);

            if (postToDelete == null || !postList.Remove(postToDelete))
            {
                return null;
            }

            _dataHandler.PostAllItems(postList, ModelType.Posts);

            return postToDelete;
        }
        
        public IEnumerable<PostDTO> DeleteAllPostsInSection(int sectionId)
        {
            var postList = _dataHandler.GetAllItems<PostDTO>(ModelType.Posts);
            var postsInSection = postList.Where(x => x.SectionId == sectionId).ToList();

            foreach (var post in postsInSection)
            {
                postList.Remove(post);
            }

            _dataHandler.PostAllItems(postList, ModelType.Posts);
            return postsInSection;
        }
    }
}