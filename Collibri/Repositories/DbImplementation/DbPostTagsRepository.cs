using AutoMapper;
using Collibri.Data;
using Collibri.Models;

namespace Collibri.Repositories.DbImplementation
{
    public class DbPostTagsRepository : IPostTagsRepository
    {
        private readonly DataContext _context;
        
        public DbPostTagsRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        
        public bool AddTagToPost(Guid tagId, Guid postId)
        {
            if (_context.PostTags.Any(x => x.PostId == postId && x.TagId == tagId))
            {
                return false;
            }
            
            _context.PostTags.Add(new PostTags { TagId = tagId, PostId = postId });
            _context.SaveChanges();

            return true;
        }
        
        public bool RemoveTagFromPost(Guid tagId, Guid postId)
        {
            var entryToDelete = _context.PostTags.SingleOrDefault(x => x.PostId == postId && x.TagId == tagId);

            if (entryToDelete == null)
            {
                return false;
            }
            
            _context.PostTags.Remove(entryToDelete);
            _context.SaveChanges();

            return true;
        }
    }
}

