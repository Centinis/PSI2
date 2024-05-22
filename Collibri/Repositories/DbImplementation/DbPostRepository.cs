using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Repositories.DbImplementation
{
    public class DbPostRepository : IPostRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public DbPostRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
    
        public PostDTO CreatePost(PostDTO post)
        {
            post.Id = Guid.NewGuid();
            post.CreationDate = DateTime.UtcNow;
            post.LastUpdatedDate = DateTime.UtcNow;
            _context.Posts.Add(_mapper.Map<Post>(post));
            _context.SaveChanges();

            return post;
        }

        public IEnumerable<PostDTO> GetAllPosts(int sectionId)
        {
            return _mapper.Map<List<PostDTO>>(_context.Posts.ToList().Where(x => x.SectionId == sectionId)).AsEnumerable();
        }

        public PostDTO? UpdatePostById(Guid postId, PostDTO post)
        {
            var postToUpdate = _context.Posts.SingleOrDefault(x => x.Id == postId);
            
            if (postToUpdate == null)
            {
                return null;
            }

            postToUpdate.LikeCount = post.LikeCount;
            postToUpdate.DislikeCount = post.DislikeCount;
            postToUpdate.Title = post.Title;
            postToUpdate.Description = post.Description;
            postToUpdate.LastUpdatedDate = DateTime.UtcNow;
            _context.Posts.Update(postToUpdate);
            _context.SaveChanges();

            return _mapper.Map<PostDTO>(postToUpdate);
        }

        public PostDTO? DeletePostById(Guid postId)
        {
            var postToDelete = _context.Posts.SingleOrDefault(x => x.Id == postId);

            if (postToDelete == null)
            {
                return null;
            }

            _context.Posts.Remove(postToDelete);
            _context.SaveChanges();

            return _mapper.Map<PostDTO>(postToDelete);
        }
    }
}