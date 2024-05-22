using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class CreateNoteTestData : TheoryData<NoteDTO, NoteDTO?, int?>
    {
        public CreateNoteTestData()
        {
            Add(new NoteDTO(Guid.NewGuid(), "NoteName", "NoteText", "NoteAuthor"), 
                new NoteDTO(Guid.NewGuid(), "NoteName", "NoteText", "NoteAuthor", 1), 
                200);
            
            Add(new NoteDTO(Guid.NewGuid(), "NoteName", "NoteText", "NoteAuthor"),
                null,
                409);
        }
    }

    // public class GetAllNotesInSectionTestData : TheoryData<int, IEnumerable<NoteDTO>>
    // {
    //     public GetAllNotesInSectionTestData()
    //     {
    //         Add(1,
    //             new List<NoteDTO>
    //             {
    //                 new NoteDTO(1, 10, Guid.NewGuid(), "NoteName", "NoteText", "NoteAuthor"),
    //                 new NoteDTO(1, 10, Guid.NewGuid(), "NoteName2", "NoteText2", "NoteAuthor2")
    //             }.AsEnumerable()
    //         );
    //         
    //         Add(1, new List<NoteDTO>().AsEnumerable());
    //     }
    // }
    
    public class UpdateNoteTestData : TheoryData<NoteDTO, NoteDTO?, int, int>
    {
        public UpdateNoteTestData()
        {
            Add(new NoteDTO(Guid.NewGuid(), "Old Name", "Old Text", "author", 1111),
                new NoteDTO(Guid.NewGuid(), "New Name", "New Text", "author", 1111),
                1111,
                200
            );
            
            Add(new NoteDTO(Guid.NewGuid(), "Old Name", "Old Text", "author", 1111), 
                null, 
                2222, 
                409);
        }
    }
}

