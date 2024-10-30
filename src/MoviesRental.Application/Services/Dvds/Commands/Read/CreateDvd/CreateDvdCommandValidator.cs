using FluentValidation;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.CreateDvd;
public class CreateDvdCommandValidator : AbstractValidator<CreateDvdCommand>
{
    public CreateDvdCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required!");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required!");

        RuleFor(x => x.Publisher)
            .NotEmpty().WithMessage("Published is required!")
            .LessThan(DateTime.UtcNow).WithMessage("Invalid date!");

        RuleFor(x => x.Genre)
            .NotEmpty().WithMessage("Genre is required!");

        RuleFor(x => x.IsAvailable)
            .Equal(true).WithMessage("Available not valid!");

        RuleFor(x => x.Copies)
            .GreaterThan(-1).WithMessage("Invalid copies!");

        RuleFor(x => x.CreateAt)
            .LessThan(DateTime.UtcNow).WithMessage("Invalid date!");
        
        RuleFor(x => x.UpdateAt)
            .LessThan(DateTime.UtcNow).WithMessage("Invalid date!");

        RuleFor(x => x.DirectorId)
            .NotEmpty().WithMessage("Invalid director id!");
    }
}
