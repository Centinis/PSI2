using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.DbImplementation
{
    public class DbDocumentRepository : IDocumentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public DbDocumentRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
    
        public DocumentDTO? CreateDocument(DocumentDTO document, string postId)
        {
            document.Id = new int().GenerateNewId(_context.Documents.Select(x => x.Id).ToList());
            document.PostId = Guid.Parse(postId);
            _context.Documents.Add(_mapper.Map<Document>(document));
            _context.SaveChanges();

            return document;
        }

        public IEnumerable<DocumentDTO> GetDocuments(string postId)
        {
            return _mapper.Map<List<DocumentDTO>>(_context.Documents.Where(document =>
                document.PostId.Equals(Guid.Parse(postId)))).AsEnumerable();
        }

        public DocumentDTO? DeleteById(int id)
        {
            var documentToDelete = _context.Documents.SingleOrDefault(x => x.Id == id);
        
            if (documentToDelete == null)
                return null;
        
            _context.Documents.Remove(documentToDelete);
            _context.SaveChanges();

            return _mapper.Map<DocumentDTO>(documentToDelete);
        }
        
        public IEnumerable<DocumentDTO> DeleteAllDocumentsInPost(Guid postId)
        {
            var documentsInPost = _context.Documents.Where(x => x.PostId == postId);

            foreach (var document in documentsInPost)
            {
                _context.Documents.Remove(document);
            }

            _context.SaveChanges();

            return _mapper.Map<List<DocumentDTO>>(documentsInPost).AsEnumerable();
        }

        public DocumentDTO? UpdateDocument(DocumentDTO document, int id)
        {
            var documentToUpdate = _context.Documents.SingleOrDefault(x => x.Id == id);
            
            if (documentToUpdate == null)
            {
                return null;
            }
            
            documentToUpdate.Title = document.Title;
            documentToUpdate.Text = document.Text;
            _context.Documents.Update(documentToUpdate);
            _context.SaveChanges();

            return _mapper.Map<DocumentDTO>(documentToUpdate);
        }
    }
}