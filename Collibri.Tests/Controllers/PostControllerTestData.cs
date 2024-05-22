using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class CreatePostTestData : TheoryData<PostDTO, PostDTO>
    {
        public CreatePostTestData()
        {
            //Correct input
            Add(new PostDTO(Guid.Empty, "user", "title", 1, 0, 0, "test", DateTime.Now, DateTime.Now),
                new PostDTO(Guid.NewGuid(), "user", "title", 1, 0, 0, "test", DateTime.Now, DateTime.Now));
        }
    }   
    
    public class GetAllPostsTestData : TheoryData<int, IEnumerable<PostDTO>>
    {
        public GetAllPostsTestData()
        {
            //Correct input
            Add(1, 
                new List<PostDTO>
                {
                    new PostDTO(Guid.NewGuid(), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                    new PostDTO(Guid.NewGuid(), "user2", "title2", 1, 2, 0, "test", DateTime.Now, DateTime.Now) 
                }.AsEnumerable()
            );
            Add(1, 
                new List<PostDTO>().AsEnumerable()
            );
        }
    }

    public class UpdatePostByIdTestData : TheoryData<Guid, PostDTO, PostDTO?, int>
    {
        public UpdatePostByIdTestData()
        {
            //Correct input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                200);
            //Failing input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "title1", 1, 0, 0, "test",  DateTime.Now, DateTime.Now),
                null,
                404);
        }
    }
    
    public class DeletePostByIdTestData : TheoryData<Guid, PostDTO?>
    {
        public DeletePostByIdTestData()
        {
            //Correct input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), 
                new PostDTO(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), "user1", "new title", 1, 2, 1, "test",  new DateTime(), new DateTime()));
            //Failing input
            Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a62"), 
                null);
        }
    }
}