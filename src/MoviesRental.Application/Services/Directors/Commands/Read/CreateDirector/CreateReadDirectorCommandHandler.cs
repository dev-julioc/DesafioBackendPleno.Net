using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Entities.Read;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.Read.CreateDirector;
public class CreateReadDirectorCommandHandler : IRequestHandler<CreateReadDirectorCommand, ResultService<bool>>
{
    private readonly IDirectorReadRepository _repository;

    public CreateReadDirectorCommandHandler(IDirectorReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(CreateReadDirectorCommand request, CancellationToken cancellationToken)
    {
        var validate = new CreateReadDirectorCommandValidator().Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<bool>("Fields validate error!", validate);

        var readDirector = await _repository.GetDirectorByIdAsync(request.Id);

        if (readDirector is not null)
            return ResultService.Fail<bool>("Director already exists!");

        readDirector = new DirectorRead
        {
            Id = request.Id,
            FullName = request.FullName,
            CreatedAt = request.CreateAt,
            UpdatedAt = request.UpdateAt,
        };

        var result = await _repository.CreateDirectorAsync(readDirector);

        if (result is null)
            return ResultService.Fail<bool>("Failed to create director!");

        return ResultService.Ok(true);  
    }
}
