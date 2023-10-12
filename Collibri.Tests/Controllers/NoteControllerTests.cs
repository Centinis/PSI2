using Collibri.Controllers;
using Collibri.Models.Notes;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Tests.Controllers
{
    public class NoteControllerTests
    {
        [Theory]
        [ClassData(typeof(CreateNoteTestData))]
        public void CreateNoteTest(
            Note note,
            Note? result,
            int? statusCode    
            )
        { 
            var repository = new Mock<INoteRepository>(); 
            var controller = new NoteController(repository.Object);
            repository.Setup(x => x.CreateNote(note)).Returns(result);

            var actual = controller.CreateNote(note);

            if (result == null)
            {
                Assert.IsType<ConflictResult>(actual);
                Assert.Equal(statusCode, ((ConflictResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
            }
        }

        [Theory]
        [ClassData(typeof(GetAllNotesInSectionTestData))]
        public void GetAllNotesInSectionTest(
            int id,
            IEnumerable<Note> result
            )
        {
            var repository = new Mock<INoteRepository>(); 
            var controller = new NoteController(repository.Object);
            repository.Setup(x => x.GetAllNotesInSection(id)).Returns(result);

            var actual = controller.GetAllNotesInSection(id) as ObjectResult;

            Assert.IsType<List<Note>>(actual?.Value);
            Assert.Equal(result, actual.Value);
        }
        
        [Theory]
        [ClassData(typeof(UpdateNoteTestData))]
        public void UpdateNoteTest(
            Note note,
            Note? updatedNote,
            int id,
            int statusCode
            )
        {
            var repository = new Mock<INoteRepository>();
            var controller = new NoteController(repository.Object);
            repository.Setup(x => x.UpdateNote(note, id)).Returns(updatedNote);
            
            var actual = controller.UpdateNote(note, id);
            
            if (updatedNote == null)
            {
                Assert.IsType<ConflictResult>(actual);
                Assert.Equal(statusCode, ((ConflictResult)actual).StatusCode);
            }
            else
            {
                Assert.IsType<OkObjectResult>(actual);
                Assert.Equal(statusCode, ((OkObjectResult)actual).StatusCode);
                Assert.Equal(updatedNote, ((ObjectResult)actual).Value);
            }
        }
    }
}

