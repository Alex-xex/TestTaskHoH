using MediatR;
using System;

namespace TestTaskHoH.Commands
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public bool Actual { get; set; }
    }
}
