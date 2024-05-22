using Collibri.Dtos;

namespace Collibri.Tests.Repositories.Documents
{
    public class CreateDocumentTestData : TheoryData<string, DocumentDTO, List<DocumentDTO>>
    {
        public CreateDocumentTestData()
        {
            //Correct input
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new DocumentDTO(6, Guid.NewGuid(), "title", "text"),
                new List<DocumentDTO>
                {
                    new DocumentDTO(15, Guid.NewGuid(), "title", "text"),
                    new DocumentDTO(481, Guid.NewGuid(), "title", "text")
                });
            //Failling input
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new DocumentDTO(50, Guid.NewGuid(), "title", "text"),
                new List<DocumentDTO>
                {
                    new DocumentDTO(50, Guid.NewGuid(), "title", "text"),
                    new DocumentDTO(481, Guid.NewGuid(), "title", "text")
                });
        }
    }

    public class GetDocumentsTestData : TheoryData<string, List<DocumentDTO>>
    {
        public GetDocumentsTestData()
        {
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61",
                new List<DocumentDTO>
                {
                    new DocumentDTO(123, Guid.NewGuid(), "matke", "text"),
                    new DocumentDTO(456, Guid.NewGuid(), "matke", "text")
                }
            );
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61",
                new List<DocumentDTO>
                {
                    new DocumentDTO(123, Guid.NewGuid(), "matke", "text"),
                    new DocumentDTO(456, Guid.NewGuid(), "matke", "text")
                }
            );
            Add("2b8b88a3-cd97-48cf-9d4d-ef8db4ac4a61", new List<DocumentDTO>());
        }
    }

    public class UpdateDocumentTestData : TheoryData<DocumentDTO, DocumentDTO?, int, List<DocumentDTO>>
    {
        public UpdateDocumentTestData()
        {
            Guid sameGuid = new Guid();
            //Correct input
            Add(new DocumentDTO(123, sameGuid, "new matke", "new text"),
                new DocumentDTO(123, sameGuid, "new matke", "new text"), 123,
                new List<DocumentDTO>
                {
                    new DocumentDTO(456, Guid.NewGuid(), "random", "random"),
                    new DocumentDTO(123, sameGuid, "to update", "to update")
                }
            );
            //Failing input
            Add(new DocumentDTO(123, Guid.NewGuid(), "matke", "text"), null, 123,
                new List<DocumentDTO>
                {
                    new DocumentDTO(456, Guid.NewGuid(), "random", "random"),
                    new DocumentDTO(12378, Guid.NewGuid(), "to update", "to update")
                }
            );
            //Failing input

            Add(new DocumentDTO(123, Guid.NewGuid(), "matke", "text"), null, 123, new List<DocumentDTO>());
        }
    }

    public class DeleteDocumentTestData : TheoryData<int, DocumentDTO?, List<DocumentDTO>>
    {
        public DeleteDocumentTestData()
        {
            Guid sameGuid = new Guid();
            //Correct input
            Add(123, new DocumentDTO(123, sameGuid, "matke to delete", "text to delete"),
                new List<DocumentDTO>
                {
                    new DocumentDTO(4561, Guid.NewGuid(), "matke random", "text random"),
                    new DocumentDTO(123, sameGuid, "matke to delete", "text to delete")
                });
            //Failing input
            Add(123, null,
                new List<DocumentDTO>
                {
                    new DocumentDTO(4561, Guid.NewGuid(), "matke random", "text random"),
                    new DocumentDTO(459, Guid.NewGuid(), "matke to delete", "text to delete")
                });
            Add(123, null, new List<DocumentDTO>());
        }
    }
}

