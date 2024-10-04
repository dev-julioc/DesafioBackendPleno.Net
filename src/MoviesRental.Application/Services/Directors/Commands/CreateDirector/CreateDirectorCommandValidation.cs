using FluentValidation;
using MoviesRental.Domain.Entities.Write;

namespace MoviesRental.Application.Services.Directors.Commands.CreateDirector;
public class CreateDirectorCommandValidation : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorCommandValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(Director.EMPTY_STRING_ERROR_MESSAGE)
            .NotNull().WithMessage(Director.EMPTY_STRING_ERROR_MESSAGE)
            .MinimumLength(Director.MIN_LENGTH).WithMessage(Director.MIN_LENGTH_ERROR_MESSAGE)
            .MaximumLength(Director.MAX_LENGTH).WithMessage(Director.MAX_LENGTH_ERROR_MESSAGE);

        RuleFor(x => x.Surname)
           .NotEmpty().WithMessage(Director.EMPTY_STRING_ERROR_MESSAGE)
           .NotNull().WithMessage(Director.EMPTY_STRING_ERROR_MESSAGE)
           .MinimumLength(Director.MIN_LENGTH).WithMessage(Director.MIN_LENGTH_ERROR_MESSAGE)
           .MaximumLength(Director.MAX_LENGTH).WithMessage(Director.MAX_LENGTH_ERROR_MESSAGE);
    }
}
