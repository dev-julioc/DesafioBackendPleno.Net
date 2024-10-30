using FluentValidation;
using MoviesRental.Domain.Entities.Write;

namespace MoviesRental.Application.Services.Dvds.Commands.Write.UpdateDvd;
public class UpdateDvdCommandValidation : AbstractValidator<UpdateDvdCommand>
{
    public UpdateDvdCommandValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(Dvd.INVALID_ERROR_MESSAGE);

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(Dvd.EMPTY_STRING_ERROR_MESSAGE)
            .NotNull().WithMessage(Dvd.EMPTY_STRING_ERROR_MESSAGE)
            .MinimumLength(Dvd.MIN_TITLE_LENGTH).WithMessage(Dvd.MIN_LENGTH_ERROR_MESSAGE)
            .MaximumLength(Dvd.MAX_TITLE_LENGTH).WithMessage(Dvd.MAX_LENGTH_ERROR_MESSAGE);

        RuleFor(x => x.Genre)
            .LessThanOrEqualTo(Dvd.GENRE_MAX_NUMBER).WithMessage(Dvd.GENRE_ERROR_MESSAGE)
            .GreaterThanOrEqualTo(Dvd.GENRE_MIN_NUMBER).WithMessage(Dvd.GENRE_ERROR_MESSAGE);

        RuleFor(x => x.Published)
            .LessThan(DateTime.UtcNow).WithMessage(Dvd.INVALID_ERROR_MESSAGE);

        RuleFor(x => x.Copies)
            .GreaterThan(Dvd.COPIES_ERROR_NUMBER).WithMessage(Dvd.INVALID_ERROR_MESSAGE);

        RuleFor(x => x.DirectorId)
            .NotEqual(Guid.Empty).WithMessage(Dvd.INVALID_ERROR_MESSAGE);
    }
}
