using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Entities.Write;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.CreateDvd;
public class CreateDvdCommandHandler : IRequestHandler<CreateDvdCommand, ResultService<CreateDvdResponse>>
{
    private readonly IDvdWriteRepository _repository;
    private readonly CreateDvdCommandValidation _validator;

    public CreateDvdCommandHandler(IDvdWriteRepository repository, CreateDvdCommandValidation validator)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<ResultService<CreateDvdResponse>> Handle(CreateDvdCommand request, CancellationToken cancellationToken)
    {
        var validate = _validator.Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<CreateDvdResponse>("Fields validate error!", validate);

        var dvd = new Dvd(request.Genre, request.Published, request.Copies, request.DirectorId);

        var result = await _repository.CreateDvdAsync(dvd);

        if (!result)
            return ResultService.Fail<CreateDvdResponse>("Failed to create dvd!");

        var response = new CreateDvdResponse
            (
                dvd.Id.ToString(),
                dvd.Title,
                dvd.Genre.ToString(),
                dvd.Publisher,
                dvd.IsAvailable,
                dvd.Copies,
                dvd.DirectorId.ToString(),
                dvd.CreatedAt,
                dvd.UpdatedAt
            );

        return ResultService.Ok(response);
        
    }
}
