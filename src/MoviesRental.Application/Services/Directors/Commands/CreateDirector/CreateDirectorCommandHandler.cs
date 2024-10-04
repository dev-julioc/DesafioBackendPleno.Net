using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Entities.Write;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.CreateDirector;
public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, ResultService<CreateDirectorReponse>>
{
    private readonly IDirectorWriteRepository _directorRepository;
    private readonly CreateDirectorCommandValidation _validator;

    public CreateDirectorCommandHandler(IDirectorWriteRepository directorRepository, CreateDirectorCommandValidation validator)
    {
        _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<ResultService<CreateDirectorReponse>> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var validate = _validator.Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<CreateDirectorReponse>("Fields validate error!", validate);

        var director = new Director(request.Name, request.Surname);

        var result = await _directorRepository.CreateDirectorAsync(director);

        if (!result)
            return ResultService.Fail<CreateDirectorReponse>("Failed to create director!");

        var response =  new CreateDirectorReponse(director.Id.ToString(), director.FullName(), director.CreatedAt, director.UpdatedAt);

        return ResultService.Ok(response);
    }
}
