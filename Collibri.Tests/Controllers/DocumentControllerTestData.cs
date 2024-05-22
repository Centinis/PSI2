using Collibri.Dtos;

namespace Collibri.Tests.Controllers
{
    public class CreateDocumentTestData : TheoryData<string, DocumentDTO, DocumentDTO?, int?>
    {
        public CreateDocumentTestData()
        {
            var sameGuid = Guid.Parse("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61");
            //Correct input
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new DocumentDTO(0, sameGuid, "matke", "text"), new DocumentDTO(1, sameGuid, "matke", "text"),
                200);
            //Failing input
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new DocumentDTO(0, Guid.NewGuid(), "matke", "text"), null, 409);
        }
    }

    public class GetDocumentsTestData : TheoryData<string, IEnumerable<DocumentDTO>>
    {
        public GetDocumentsTestData()
        {
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61",
                new List<DocumentDTO>
                {
                    new DocumentDTO(123, Guid.NewGuid(), "matke", "text"),
                    new DocumentDTO(456, Guid.NewGuid(), "matke", "text")
                }.AsEnumerable()
            );
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new List<DocumentDTO>().AsEnumerable());
        }
    }

    public class UpdateDocumentTestData : TheoryData<DocumentDTO, DocumentDTO?, int, int>
    {
        public UpdateDocumentTestData()
        {
            // Correct input
            Add(new DocumentDTO(123, Guid.NewGuid(), "old matke", " old text"),
                new DocumentDTO(123, Guid.NewGuid(), "new matke", "new text"), 123, 200);
            //Failing input
            Add(new DocumentDTO(123, Guid.NewGuid(), "old matke", " old text"), null, 123, 404);
        }
    }

    public class DeleteDocumentTestData : TheoryData<int, DocumentDTO?, int>
    {
        public DeleteDocumentTestData()
        {
            //Correct input
            Add(123, new DocumentDTO(123, Guid.NewGuid(), "matke", "text"), 200);
            //Failing input
            Add(123, null, 404);
        }
    }
}
