using Collibri.Dtos;
using Collibri.Models;

namespace Collibri.Tests.Repositories.Notes
{
    public class DbCreateNoteTestData : TheoryData<NoteDTO, NoteDTO?, List<Note>>
    {
        public DbCreateNoteTestData()
        {
            Add(new NoteDTO(Guid.NewGuid(), "testNote1", "testText1", "author1"), null,
                new List<Note>
                {
                    new Note { PostId = Guid.NewGuid(), Name = "existingNote", Text = "text", Author = "existingAuthor" },
                    new Note { PostId = Guid.NewGuid(),Name = "existingNote2", Text = "text", Author = "existingAuthor2" }
                }
            );
            
            Add(new NoteDTO(Guid.NewGuid(),"testNote1", "testText1", "author1"), null,
                new List<Note>
                {
                    new Note { PostId = Guid.NewGuid(), Name = "testNote1", Text = "text", Author = "existingAuthor" },
                    new Note { PostId = Guid.NewGuid(), Name = "existingNote2", Text = "text", Author = "existingAuthor2" }
                }
            );
            Add(new NoteDTO(Guid.NewGuid(),"testNote1", "testText1", "author1"), null,
                new List<Note>
                {
                    new Note{ PostId = Guid.NewGuid(), Name = "existingNote", Text = "text", Author = "existingAuthor" },
                    new Note{ PostId = Guid.NewGuid(), Name = "testNote1", Text = "text", Author = "existingAuthor2" }
                }
            );
        }
    }

    public class DbGetNoteTestData : TheoryData<int, Note?, List<Note>>
    {
        private readonly Note? _expected1 = new Note{PostId = Guid.NewGuid(), Name = "existingNote1", Text = "text", Author = "existingAuthor1", Id = 1010};
        public DbGetNoteTestData()
        {
            Add(1010, _expected1,
                new List<Note>
                {
                    _expected1,
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote2", Text = "text", Author = "existingAuthor2", Id = 2020},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote3", Text = "text", Author = "existingAuthor3", Id = 3030}
                }
            );
            Add(4040, null,
                new List<Note>
                {
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote1", Text = "text", Author = "existingAuthor1", Id = 1010},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote2", Text = "text", Author = "existingAuthor2", Id = 2020},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote3", Text = "text", Author = "existingAuthor3", Id = 3030}
                }
            );
        }
    }

    public class DbGetNotesInPostTestData : TheoryData<Guid, List<Note>, List<Note>>
    {
        private readonly Note? _expected1 = new Note {PostId = Guid.Parse("983b00d6-f8c2-4e10-816f-0970416ca85f"), Name = "test", Text = "test", Author = "test", Id = 1};
        private readonly Note? _expected2 = new Note {PostId = Guid.Parse("983b00d6-f8c2-4e10-816f-0970416ca85f"), Name = "test", Text = "test", Author = "test", Id = 2};
        public DbGetNotesInPostTestData()
        {
            Add(Guid.Parse("983b00d6-f8c2-4e10-816f-0970416ca85f"), 
                new List<Note>
                {
                    _expected1,
                    _expected2
                },
                new List<Note>
                {
                    _expected1,
                    new Note {PostId = Guid.Parse("cbe1bf3e-8ec1-4846-bbca-981476e334c7"), Name = "test", Text = "test", Author = "test", Id = 3},
                    _expected2,
                    new Note {PostId = Guid.Parse("cbe1bf3e-8ec1-4846-bbca-981476e334c7"), Name = "test", Text = "test", Author = "test", Id = 4},
                    new Note {PostId = Guid.Parse("39f93daa-5f88-470a-8d0b-10e7b67bc289"), Name = "test", Text = "test", Author = "test", Id = 5},
                }
                
            );
            Add(Guid.Parse("983b00d6-f8c2-4e10-816f-0970416ca85f"), 
                new List<Note>(),
                new List<Note>
                {
                    new Note {PostId = Guid.Parse("cbe1bf3e-8ec1-4846-bbca-981476e334c7"), Name = "test", Text = "test", Author = "test", Id = 3},
                    new Note {PostId = Guid.Parse("cbe1bf3e-8ec1-4846-bbca-981476e334c7"), Name = "test", Text = "test", Author = "test", Id = 4},
                    new Note {PostId = Guid.Parse("39f93daa-5f88-470a-8d0b-10e7b67bc289"), Name = "test", Text = "test", Author = "test", Id = 5},
                }
                
            );
        }
    }

    public class DbDeleteNoteTestData : TheoryData<int, Note?, List<Note>>
    {
        private readonly Note? _expected1 = new Note{PostId = Guid.NewGuid(), Name = "existingNote1", Text = "text", Author = "existingAuthor1", Id = 1010};
        
        public DbDeleteNoteTestData()
        {
            Add(1010, _expected1,
                new List<Note>
                {
                    _expected1,
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote2", Text = "text", Author = "existingAuthor2", Id = 2020},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote3", Text = "text", Author = "existingAuthor3", Id = 3030}
                }
            );
            Add(4040, null,
                new List<Note>
                {
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote1", Text = "text", Author = "existingAuthor1", Id = 1010},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote2", Text = "text", Author = "existingAuthor2", Id = 2020},
                    new Note{PostId = Guid.NewGuid(), Name = "existingNote3", Text = "text", Author = "existingAuthor3", Id = 3030}
                }
            );
        }
    }
}

