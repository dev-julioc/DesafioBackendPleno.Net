using FluentValidation;

namespace MoviesRental.Application.Services.Directors.Commands.Read.UpdateDirector;
public class UpdateReadDirectorCommandValidator : AbstractValidator<UpdateReadDirectorCommand>
{
    public UpdateReadDirectorCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required!")
           .NotNull().WithMessage("Id is required!");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required!")
            .NotNull().WithMessage("Full name is required!")
            .MinimumLength(3).WithMessage("Invalid full name! Minimum 3 characteres!")
            .MaximumLength(60).WithMessage("Invalid full name! Maximum 60 characteres!");

        RuleFor(x => x.UpdateAt)
            .LessThan(DateTime.Now).WithMessage("Invalid updateAt");
    }
}
