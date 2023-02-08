using System;
using FluentValidation;

namespace TestTaskHoH.Queries.Validation
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(note => note.Id).NotEqual(Guid.Empty);           
        }
    }
}
