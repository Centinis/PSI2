using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Tests.Repositories.Posts
{
    public class DbCreatePostTestData : TheoryData<PostDTO, int, PostDTO, List<Post>>
    {
        public DbCreatePostTestData()
        {
            var post = new PostDTO(Guid.NewGuid(), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            
            Add(post, 1, post, new List<Post>());
        }
    }

    public class DbGetAllPostsTestData : TheoryData<List<Post>, int, List<Post>>
    {
        public DbGetAllPostsTestData()
        {
            var post1 = new Post(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"),"user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            var post2 = new Post(Guid.Parse("6febd4b4-2d15-4e84-9c1a-60f4703d1b3a"), "user2", "title2", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            var post3 = new Post(Guid.Parse("a81c5e20-18c2-4e03-9f0a-978468c04d25"), "user2", "title3", 2, 0, 0, "test",  DateTime.Now, DateTime.Now);
            
            Add(new List<Post>()
                {
                    post1, post2, post3
                },  1, 
                    new List<Post>()
                {
                    post1, post2
                });
            Add(new List<Post>()
                {
                    post1, post2, post3
                }, 3,
                new List<Post>());
        }
    }

    public class DbUpdatePostTestData : TheoryData<PostDTO, Guid, int, PostDTO, List<Post>>
    {
        public DbUpdatePostTestData()
        {
            var post1 = new Post(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"),"user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            var post2 = new Post(Guid.Parse("6febd4b4-2d15-4e84-9c1a-60f4703d1b3a"), "user2", "title2", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);

            var post1dto = new PostDTO(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"), "user1", "title3", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
  
            Add(post1dto, Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"), 1, post1dto, new List<Post>(){post1, post2});
            Add(post1dto, Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a90"), 0, null, new List<Post>(){post1, post2});
        }
    }

    public class DbDeletePostTestData : TheoryData<Guid, int, PostDTO?, List<Post>>
    {
        public DbDeletePostTestData()
        {
            var post1 = new Post(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"),"user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            var post2 = new Post(Guid.Parse("6febd4b4-2d15-4e84-9c1a-60f4703d1b3a"), "user2", "title2", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            
            var post1dto = new PostDTO(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now);
            
            Add(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a97"), 1, post1dto, new List<Post>() { post1, post2 });
            Add(Guid.Parse("4d189c13-1e78-4a72-8b5c-4ef51ef01a90"), 0, null, new List<Post>() { post1, post2 });
        }
    }
}