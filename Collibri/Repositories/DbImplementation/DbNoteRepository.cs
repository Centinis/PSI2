using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Collibri.Models;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.DbImplementation
{
    public class DbNoteRepository : INoteRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public DbNoteRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
    
        public NoteDTO? CreateNote(NoteDTO note)
        {
            var noteList = _context.Notes.ToList();
            
            if (noteList.Any(notes => notes.Name.Equals(note.Name)))
            {
                return null;
            }
            
            note.Id = new int().GenerateNewId(noteList.Select(x => x.Id).ToList());
            note.CreationDate = DateTime.UtcNow;
            note.LastUpdatedDate = note.CreationDate;

            _context.Notes.Add(_mapper.Map<Note>(note));
            _context.SaveChanges();

            return note;
        }

        public NoteDTO? GetNote(int id)
        {
            var noteList = _context.Notes.ToList();

            return noteList.Any(x => x.Id == id) ? _mapper.Map<NoteDTO>(noteList.FirstOrDefault(x => x.Id == id)) : null;
        }
        
        public IEnumerable<NoteDTO> GetAllNotesByPost(Guid postId)
        {
            var notesInPost = _context.Notes.ToList().Where(note => note.PostId == postId);
            
            return _mapper.Map<List<NoteDTO>>(notesInPost).AsEnumerable();
        }

        public NoteDTO? DeleteNote(int id)
        {
            var noteToDelete = _context.Notes.SingleOrDefault(x => x.Id == id);

            if (noteToDelete == null)
            {
                return null;
            }

            _context.Notes.Remove(noteToDelete);
            _context.SaveChanges();

            return _mapper.Map<NoteDTO>(noteToDelete);
        }
        
        public IEnumerable<NoteDTO> DeleteAllNotesInPost(Guid postId)
        {
            var notesInPost = _context.Notes.Where(x => x.PostId == postId);

            foreach (var note in notesInPost)
            {
                _context.Notes.Remove(note);
            }

            _context.SaveChanges();

            return _mapper.Map<List<NoteDTO>>(notesInPost).AsEnumerable();
        }

        public NoteDTO? UpdateNote(NoteDTO note, int id)
        {
            var noteList = _context.Notes.ToList();
            var targetNote = noteList.FirstOrDefault(notes => notes.Id == id);

            if (targetNote == null)
                return null;
        
            targetNote.Name = note.Name; 
            targetNote.Text = note.Text;
            targetNote.LastUpdatedDate = DateTime.UtcNow;

            _context.Notes.Update(targetNote);
            _context.SaveChanges();
        
            return _mapper.Map<NoteDTO>(targetNote);
        }
    }
}