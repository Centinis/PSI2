using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface IDocumentRepository
    {
        public DocumentDTO? CreateDocument(DocumentDTO document, string postId);
        public IEnumerable<DocumentDTO> GetDocuments(string postId);
        public DocumentDTO? DeleteById(int id);
        public IEnumerable<DocumentDTO> DeleteAllDocumentsInPost(Guid postId);
        public DocumentDTO? UpdateDocument(DocumentDTO document, int id);
    }
}