using System;
using MediatR;
using TestTaskHoH.Entitys;
using TestTaskHoH.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestTaskHoH.Exceptions;
using System.Threading.Tasks;
using System.Threading;

namespace TestTaskHoH.Commands
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public UpdateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NoteEntity), request.Id);
            }

            entity.Info = request.Info;
            entity.Title = request.Title;
            entity.Actual = request.Actual;
            entity.UpdatedDateTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
