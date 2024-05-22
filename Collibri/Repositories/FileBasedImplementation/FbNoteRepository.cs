using Collibri.Dtos;
using Collibri.Repositories.DataHandling;
using Collibri.Repositories.ExtensionMethods;

namespace Collibri.Repositories.FileBasedImplementation
{
    public class FbNoteRepository : INoteRepository
    {
        private readonly IDataHandler _dataHandler;

        public FbNoteRepository(IDataHandler dataHandler)
        {
            this._dataHandler = dataHandler;
        }

        public NoteDTO? CreateNote(NoteDTO note)
        {
            List<NoteDTO> noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
            
            foreach (var notes in noteList)
            {
                if (notes.Name.Equals(note.Name))
                {
                    return null;
                }
            }
            
            note.Id = new int().GenerateNewId(noteList.Select(x => x.Id).ToList());
            note.CreationDate = DateTime.Now;
            note.LastUpdatedDate = note.CreationDate;
            noteList.Add(note);
            
            _dataHandler.PostAllItems(noteList, ModelType.Notes);
            
            return note;
        }

        public NoteDTO? GetNote(int id)
        {
            List<NoteDTO> noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);

            if (noteList.Any(x => x.Id == id))
            {
                return noteList.FirstOrDefault(x => x.Id == id);
            }

            return null;
        }

        public IEnumerable<NoteDTO> GetAllNotesByPost(Guid postId)
        {
            var noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
            var notesInPost = noteList.Where(note => note.PostId == postId);
            
            return notesInPost;
        }
        
        // public IEnumerable<NoteDTO> GetAllNotesInRoom(int roomId)
        // {
        //     var noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
        //     var notesInSection = noteList.Where(note => note.RoomId == roomId);
        //     
        //     return notesInSection;
        // }

        public NoteDTO? DeleteNote(int id)
        {
            List<NoteDTO> noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
            
            foreach (var note in noteList)
            {
                if (note.Id == id)
                {
                    noteList.Remove(note);
                    _dataHandler.PostAllItems(noteList, ModelType.Notes);
                    return note;
                }
            }
            
            return null;
        }
        
        public IEnumerable<NoteDTO> DeleteAllNotesInPost(Guid postId)
        {
            var noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
            var notesInPost = noteList.Where(x => x.PostId == postId).ToList();

            foreach (var note in notesInPost)
            {
                noteList.Remove(note);
            }

            _dataHandler.PostAllItems(noteList, ModelType.Notes);
            return notesInPost;
        }

        public NoteDTO? UpdateNote(NoteDTO note, int id)
        {
            List<NoteDTO> noteList = _dataHandler.GetAllItems<NoteDTO>(ModelType.Notes);
            var targetNote = noteList.FirstOrDefault(notes => notes.Id == id);

            if (targetNote != null)
            { 
                targetNote.Name = note.Name; 
                targetNote.Text = note.Text;
                targetNote.LastUpdatedDate = DateTime.Now;

                _dataHandler.PostAllItems(noteList, ModelType.Notes); 
                return targetNote;
            }

            return null;
        }

    }
}
