using MediatR;
using System;

namespace TestTaskHoH.Queries
{
    public class GetNoteDetailsQuery : IRequest<NoteDetailsVM>
    {
        public Guid Id { get; set; }       
    }
}
