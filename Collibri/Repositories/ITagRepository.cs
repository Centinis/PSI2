using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface ITagRepository
    {
        public TagDTO? CreateTag(TagDTO tag);
        public IEnumerable<TagDTO> GetAllTagsInRoom(int roomId);
        public TagDTO? UpdateTag(Guid tagId, TagDTO newTag);
        public TagDTO? DeleteTag(Guid tagId);
        public IEnumerable<TagDTO> GetTagsOnPost(Guid postId);
    }
}

