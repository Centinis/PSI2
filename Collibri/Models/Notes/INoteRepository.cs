﻿namespace Collibri.Models.Notes
{
    public interface INoteRepository
    {
        public Note? CreateNote(Note note);
        public Note? GetNote(int id);
        public Note? DeleteNote(int id);
        public Note? UpdateNote(Note note, int id);
        public IEnumerable<Note> GetAllNotesInSection(int sectionId);
        public IEnumerable<Note> GetAllNotesInRoom(int roomId);
    }
}
