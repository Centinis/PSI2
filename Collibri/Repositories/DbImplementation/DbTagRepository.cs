using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.DbImplementation
{
    public class DbTagRepository : ITagRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
    
        public DbTagRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        
        public TagDTO? CreateTag(TagDTO tag)
        {
            var tagList = _context.Tags.ToList();
                
            if (tagList.Any(t => t.Name.Equals(tag.Name) && t.RoomId == tag.RoomId))
            {
                return null;
            }
    
            tag.Id = Guid.NewGuid();
    
            _context.Tags.Add(_mapper.Map<Tag>(tag));
            _context.SaveChanges();
    
            return tag;
        }
        
        public IEnumerable<TagDTO> GetAllTagsInRoom(int roomId)
        {
            //var tagsInRoom = 
            return _mapper.Map<List<TagDTO>>(_context.Tags.ToList().Where(x => x.RoomId == roomId)).AsEnumerable();
        }
        
        public TagDTO? UpdateTag(Guid tagId, TagDTO newTag)
        {
            var tagToUpdate = _context.Tags.SingleOrDefault(x => x.Id == tagId);
                
            if (tagToUpdate == null)
            {
                return null;
            }
    
            tagToUpdate.Name = newTag.Name;
            //new fields go here
            
            _context.Tags.Update(tagToUpdate);
            _context.SaveChanges();
    
            return _mapper.Map<TagDTO>(tagToUpdate);
        }
        
        public TagDTO? DeleteTag(Guid tagId)
        {
            var tagToUpdate = _context.Tags.SingleOrDefault(x => x.Id == tagId);
                
            if (tagToUpdate == null)
            {
                return null;
            }
        
            _context.Tags.Remove(tagToUpdate);
            _context.SaveChanges();
        
            return _mapper.Map<TagDTO>(tagToUpdate);
        }

        public IEnumerable<TagDTO> GetTagsOnPost(Guid postId)
        {
            var tagIds = _context.PostTags.Where(x => x.PostId == postId).Select(entry => entry.TagId).AsEnumerable();
            var tags = _context.Tags.Where(x => tagIds.Contains(x.Id)).AsEnumerable();

            return _mapper.Map<List<TagDTO>>(tags).AsEnumerable();
        }
    }
}

