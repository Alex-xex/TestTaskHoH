using System;
using FluentValidation;

namespace TestTaskHoH.Commands.Validation
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(createNoteCommand =>
                createNoteCommand.Info).NotEmpty().MaximumLength(1024);           
        }
    }
}
