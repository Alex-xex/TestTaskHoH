using System;
using AutoMapper.QueryableExtensions;
using MediatR;
using TestTaskHoH.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace TestTaskHoH.Queries
{
    public class GetNoteListQueryHandler : IRequestHandler<GetNoteListQuery, GetNoteListVM>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteListQueryHandler(INotesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GetNoteListVM> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
        {
            var noteList = await _dbContext.Notes               
                .ProjectTo<GetNoteList>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GetNoteListVM { Notes = noteList };
        }
    }
}
