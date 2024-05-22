using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Tests.Repositories.Tags
{
    public class DbTagRepositoryTestData
    {
        //tag, expected, list
        public class DbCreateTagTestData : TheoryData<TagDTO, TagDTO?, List<Tag>>
        {
            public DbCreateTagTestData()
            {
                Add(new TagDTO {Name = "tag", RoomId = 11111}, null, 
                    new List<Tag> {
                        new Tag {Name = "test1", RoomId = 11111},
                        new Tag {Name = "test2", RoomId = 11111},
                        new Tag {Name = "test3", RoomId = 22222},
                        new Tag {Name = "test4", RoomId = 22222},
                    }
                );
                
                Add(new TagDTO {Name = "tag", RoomId = 11111}, null, 
                    new List<Tag> {
                        new Tag {Name = "test1", RoomId = 11111},
                        new Tag {Name = "tag", RoomId = 11111},
                        new Tag {Name = "test3", RoomId = 22222},
                        new Tag {Name = "test4", RoomId = 22222},
                    }
                );
            }
        }

        public class DbGetAllTagsInRoomTestData : TheoryData<int, List<Tag>, List<Tag>>
        {
            private readonly Tag? _expected1 = new Tag { Name = "tag1", RoomId = 11111, Id = Guid.NewGuid()};
            private readonly Tag? _expected2 = new Tag { Name = "tag2", RoomId = 11111, Id = Guid.NewGuid() };
            private readonly Tag? _expected3 = new Tag { Name = "tag3", RoomId = 11111, Id = Guid.NewGuid() };
            
            public DbGetAllTagsInRoomTestData()
            {
                Add(11111, 
                    new List<Tag>
                    {
                        _expected1,
                        _expected2,
                        _expected3
                    }, 
                    new List<Tag>
                    {
                        _expected1,
                        new Tag { Name = "test1", RoomId = 22222, Id = Guid.NewGuid() },
                        new Tag { Name = "test2", RoomId = 33333, Id = Guid.NewGuid() },
                        _expected2,
                        new Tag { Name = "test3", RoomId = 55555, Id = Guid.NewGuid() },
                        _expected3,
                        new Tag { Name = "test4", RoomId = 22222, Id = Guid.NewGuid() }
                    }
                    
                );
                Add(11111,
                    new List<Tag>(), 
                    new List<Tag>
                    {
                        new Tag { Name = "test1", RoomId = 22222, Id = Guid.NewGuid() },
                        new Tag { Name = "test2", RoomId = 33333, Id = Guid.NewGuid() },
                        new Tag { Name = "test3", RoomId = 55555, Id = Guid.NewGuid() },
                        new Tag { Name = "test4", RoomId = 22222, Id = Guid.NewGuid() }
                    }
                    
                    );
            }
        }
        
        public class DbDeleteTagTestData : TheoryData<Guid, Tag?, List<Tag>>
        {
            private readonly Tag? _expected1 = new Tag {Name = "tag", RoomId = 11111, Id = Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9")};
        
            public DbDeleteTagTestData()
            {
                Add(Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9"), _expected1,
                    new List<Tag>
                    {
                        _expected1,
                        new Tag {Name = "test1", RoomId = 11111, Id = Guid.NewGuid()},
                        new Tag {Name = "test2", RoomId = 11111, Id = Guid.NewGuid()}
                    }
                );
                Add(Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9"), null,
                    new List<Tag>
                    {
                        new Tag {Name = "test1", RoomId = 11111, Id = Guid.NewGuid()},
                        new Tag {Name = "test2", RoomId = 11111, Id = Guid.NewGuid()},
                        new Tag {Name = "test3", RoomId = 22222, Id = Guid.NewGuid()}
                    }
                );
            }
        }

        public class DbUpdateTagTestData : TheoryData<Guid, TagDTO?, List<Tag>>
        {
            public DbUpdateTagTestData()
            {
                Add(Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9"),
                        new TagDTO {Name = "testing", RoomId = 11111, Id = Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9")},
                        new List<Tag>
                        {
                            new Tag {Name = "test1", RoomId = 11111, Id = Guid.NewGuid()},
                            new Tag {Name = "test2", RoomId = 11111, Id = Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9")},
                            new Tag {Name = "test3", RoomId = 22222, Id = Guid.NewGuid()}
                        }
                );
                Add(Guid.Parse("a003c0aa-f25e-4748-81c7-d91a970b14b9"),
                    null,
                    new List<Tag>
                    {
                        new Tag {Name = "test1", RoomId = 11111, Id = Guid.NewGuid()},
                        new Tag {Name = "test2", RoomId = 11111, Id = Guid.NewGuid()},
                        new Tag {Name = "test3", RoomId = 22222, Id = Guid.NewGuid()}
                    }
                );
            }
        }
    }
}

