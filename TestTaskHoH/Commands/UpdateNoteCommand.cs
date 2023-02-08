using System;
using MediatR;

namespace TestTaskHoH.Commands
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Actual { get; set; }
    }
}
