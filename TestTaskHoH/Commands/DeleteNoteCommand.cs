using System;
using MediatR;

namespace TestTaskHoH.Commands
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
