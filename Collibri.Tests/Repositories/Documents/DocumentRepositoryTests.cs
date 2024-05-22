using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.FileBasedImplementation;

namespace Collibri.Tests.Repositories.Documents
{
    public class DocumentRepositoryTests
    {
        [Theory]
        [ClassData(typeof(CreateDocumentTestData))]
        public void CreateDocument_Should_ReturnDocument_WhenIdIsUnique(
            string postId,
            DocumentDTO document,
            List<DocumentDTO> list)
        {
            //Assign
            DocumentDTO? expected = null;
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbDocumentRepository(dataHandler.Object);
            dataHandler.Setup(x => x.GetAllItems<DocumentDTO>(ModelType.Documents)).Returns(list);

            //Act
            var actual = repository.CreateDocument(document, postId);

            if (actual != null)
            {
                expected = document;
                expected.PostId = actual.PostId;
            }

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(GetDocumentsTestData))]
        public void GetDocuments_Should_ReturnDocumentsInSection(
            string postId,
            List<DocumentDTO> list)
        {
            //Assign
            DocumentDTO? expected = null;
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbDocumentRepository(dataHandler.Object);
            dataHandler.Setup(x => x.GetAllItems<DocumentDTO>(ModelType.Documents)).Returns(list);

            //Act
            var actual = repository.GetDocuments(postId);


            //Assert
            Assert.Equal(list.Where(item => item.PostId == Guid.Parse(postId)).AsEnumerable(), actual);
        }

        [Theory]
        [ClassData(typeof(UpdateDocumentTestData))]
        public void UpdateDocument_Should_ReturnUpdatedDocument_IfExists(
            DocumentDTO document,
            DocumentDTO? expected,
            int documentId,
            List<DocumentDTO> list)
        {
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbDocumentRepository(dataHandler.Object);
            dataHandler.Setup(x => x.GetAllItems<DocumentDTO>(ModelType.Documents)).Returns(list);

            //Act
            var actual = repository.UpdateDocument(document, documentId);

            //Assert
            Assert.Equivalent(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DeleteDocumentTestData))]
        public void DeleteDocument_Should_ReturnDeletedDocument_IfExists(
            int documentId,
            DocumentDTO? expected,
            List<DocumentDTO> list)
        {
            //Assign
            var dataHandler = new Mock<IDataHandler>();
            var repository = new FbDocumentRepository(dataHandler.Object);
            dataHandler.Setup(x => x.GetAllItems<DocumentDTO>(ModelType.Documents)).Returns(list);

            //Act
            var actual = repository.DeleteById(documentId);


            //Assert
            Assert.Equivalent(expected, actual);
        }
    }
}

