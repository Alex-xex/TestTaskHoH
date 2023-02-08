using System;

namespace TestTaskHoH.Entitys
{
    public class NoteEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }    
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Actual { get; set; }
    }
}
