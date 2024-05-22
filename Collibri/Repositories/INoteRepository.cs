using Collibri.Dtos;

namespace Collibri.Repositories
{
    public interface INoteRepository
    {
        public NoteDTO? CreateNote(NoteDTO note);
        public NoteDTO? GetNote(int id);
        public NoteDTO? DeleteNote(int id);
        public IEnumerable<NoteDTO> DeleteAllNotesInPost(Guid postId);
        public NoteDTO? UpdateNote(NoteDTO note, int id);
        public IEnumerable<NoteDTO> GetAllNotesByPost(Guid postId);
        // public IEnumerable<NoteDTO> GetAllNotesInRoom(int roomId);
    }
}
