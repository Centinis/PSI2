namespace Collibri.Repositories
{
    public interface IPostTagsRepository
    {
        public bool AddTagToPost(Guid tagId, Guid postId);
        public bool RemoveTagFromPost(Guid tagId, Guid postId);
    }
}

