using Collibri.Dtos;

namespace Collibri.Tests.Repositories.Posts
{
    public class CreatePostTestData : TheoryData<PostDTO>
    {
        public CreatePostTestData()
        {
            //Correct input
            Add(new PostDTO(Guid.NewGuid(), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now));
        }
    }

    public class GetAllPostsTestData : TheoryData<int, List<PostDTO>>
    {
        public GetAllPostsTestData()
        {
            //Correct inputs
            Add(1, 
                new List<PostDTO>
                {
                    new PostDTO(Guid.NewGuid(), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                    new PostDTO(Guid.NewGuid(), "user2", "title2", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                    new PostDTO(Guid.NewGuid(), "user3", "title3", 2, 0, 0, "test",  DateTime.Now, DateTime.Now)
                }
            );
            Add(1, new List<PostDTO>());
        }
    }

    public class UpdatePostByIdTestData : TheoryData<Guid, PostDTO, PostDTO?, List<PostDTO>>
    {
        public UpdatePostByIdTestData()
        {
            //Correct input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "new title", 1, 2, 1, "test",  new DateTime(), new DateTime()),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "new title", 1, 2, 1, "test",  new DateTime(), new DateTime()),
                new List<PostDTO>
                {
                    new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                    new PostDTO(Guid.NewGuid(), "user2", "title2", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                    new PostDTO(Guid.NewGuid(), "user3", "title3", 2, 0, 0, "test",  new DateTime(), new DateTime())
                }
            );
            //Failing inputs
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "new title", 1, 2, 1, "test",  new DateTime(), new DateTime()),
                null,
                new List<PostDTO>
                {
                    new PostDTO(new Guid("222222a3-2297-48cf-9d4d-2222224a2262"), "user1", "title1", 1, 0, 0, "test", new DateTime(), new DateTime()),
                    new PostDTO(new Guid("222222a3-2297-48cf-9d4d-2222224a2261"), "user2", "title2", 1, 0, 0, "test", new DateTime(), new DateTime())
                }
            );
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "new title", 1, 2, 1, "test",  new DateTime(), new DateTime()),
                null,
                new List<PostDTO>()
            );
        }
    }
    
    public class DeletePostByIdTestData : TheoryData<Guid, PostDTO?, List<PostDTO>>
    {
        public DeletePostByIdTestData()
        {
            //Correct input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                new List<PostDTO>
                {
                    new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                    new PostDTO(Guid.NewGuid(), "user2", "title2", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                    new PostDTO(Guid.NewGuid(), "user3", "title3", 2, 0, 0, "test",  new DateTime(), new DateTime())
                }
            );
            //Failing input
            Add(new Guid("a4e38bc3-2dc0-4c61-a4c9-5ab59f8a5f57"),
                null,
                new List<PostDTO>
                {
                    new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  new DateTime(), new DateTime()),
                }
            );
        }
    }
}
