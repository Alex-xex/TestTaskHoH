using System;
using FluentValidation;

namespace TestTaskHoH.Commands.Validation
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {          
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(updateNoteCommand => updateNoteCommand.Info).NotEmpty().MaximumLength(1024);
        }
    }
}
