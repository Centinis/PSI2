using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class TagControllerTestData
    {
        public class CreateTagTestData : TheoryData<TagDTO, TagDTO>
        {
            public CreateTagTestData()
            {
                //Correct input
                Add( new TagDTO { Id = Guid.Empty, Name = "1", RoomId = 1 },
                     new TagDTO { Id = Guid.NewGuid(), Name = "1", RoomId = 1 });
            }
        }

        public class GetAllTagsTestData : TheoryData<int, IEnumerable<TagDTO>>
        {
            public GetAllTagsTestData()
            {
                Add(1,
                    new List<TagDTO>
                    {
                        new TagDTO { Id = Guid.NewGuid(), Name = "1", RoomId = 1 },
                        new TagDTO { Id = Guid.NewGuid(), Name = "2", RoomId = 1 }
                    }.AsEnumerable()
                );
                Add(1,
                    new List<TagDTO>().AsEnumerable()
                );
            }
        }

        public class UpdateTagTestData : TheoryData<Guid, TagDTO, TagDTO?, int>
        {
            public UpdateTagTestData()
            {
                Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                    new TagDTO { Id = new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), Name = "1", RoomId = 1},
                    new TagDTO { Id = new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), Name = "1", RoomId = 1},
                    200);

                Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                    new TagDTO { Id = new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), Name = "1", RoomId = 1},
                    null,
                    404);
            }
        }

        public class DeleteTagTestData : TheoryData<Guid, TagDTO?>
        {
            public DeleteTagTestData()
            {
                Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"),
                    new TagDTO{Id = new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61"), Name = "1", RoomId = 1}
                );
                Add(new Guid("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a62"), 
                    null);
            }
        }
    }
}

