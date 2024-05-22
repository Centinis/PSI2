using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.FileBasedImplementation
{
    public class FbDocumentRepository : IDocumentRepository
    {
        private readonly IDataHandler _dataHandler;
        
        public FbDocumentRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public DocumentDTO? CreateDocument(DocumentDTO document, string postId)
        {
            var documentList = _dataHandler.GetAllItems<DocumentDTO>(ModelType.Documents);
            document.Id = new int().GenerateNewId(documentList.Select(x => x.Id).ToList());

            foreach (var doc in documentList)
            {
                if (doc.Id == document.Id)
                {
                    return null;
                }
            }

            document.PostId = Guid.Parse(postId);
            documentList.Add(document);

            _dataHandler.PostAllItems(documentList, ModelType.Documents);

            return document;
        }

        public IEnumerable<DocumentDTO> GetDocuments(string PostId)
        {
            var documentList = _dataHandler.GetAllItems<DocumentDTO>(ModelType.Documents);
            return documentList.Where(document => document.PostId.Equals(Guid.Parse(PostId)));
        }

        public DocumentDTO? DeleteById(int id)
        {
            var documentList = _dataHandler.GetAllItems<DocumentDTO>(ModelType.Documents);
            var documentToDelete = documentList.SingleOrDefault(x => x.Id == id);
            
            if (documentToDelete == null || !documentList.Remove(documentToDelete))
            {
                return null;
            }
            
            _dataHandler.PostAllItems(documentList, ModelType.Documents);
            return documentToDelete;
        }
        
        public IEnumerable<DocumentDTO> DeleteAllDocumentsInPost(Guid postId)
        {
            var documentList = _dataHandler.GetAllItems<DocumentDTO>(ModelType.Documents);
            var documentsInPost = documentList.Where(x => x.PostId == postId).ToList();

            foreach (var document in documentsInPost)
            {
                documentList.Remove(document);
            }

            _dataHandler.PostAllItems(documentList, ModelType.Documents);
            return documentsInPost;
        }

        public DocumentDTO? UpdateDocument(DocumentDTO document, int id)
        {
            var documentList = _dataHandler.GetAllItems<DocumentDTO>(ModelType.Documents);
            var documentToUpdate = documentList.SingleOrDefault(x => x.Id == id);
            
            if (documentToUpdate == null)
            {
                return null;
            }
            
            documentToUpdate.Title = document.Title;
            documentToUpdate.Text = document.Text;
            _dataHandler.PostAllItems(documentList, ModelType.Documents);

            return documentToUpdate;
        }
    }
}