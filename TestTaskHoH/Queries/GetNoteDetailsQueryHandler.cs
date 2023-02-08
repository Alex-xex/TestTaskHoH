using MediatR;
using TestTaskHoH.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestTaskHoH.Exceptions;
using TestTaskHoH.Entitys;
using System.Threading.Tasks;
using System.Threading;


namespace TestTaskHoH.Queries
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVM>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVM> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(NoteEntity), request.Id);
            }

            return _mapper.Map<NoteDetailsVM>(entity);

        }
    }
}
