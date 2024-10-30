using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.CreateDvd;
public class CreateDvdCommandHandler : IRequestHandler<CreateDvdCommand, ResultService<bool>>
{
    private readonly IDvdReadRepository _repository;

    public CreateDvdCommandHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(CreateDvdCommand request, CancellationToken cancellationToken)
    {
        var validate = new CreateDvdCommandValidator().Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<bool>("Fields validate error!", validate);

        var dvd = await _repository.GetDvdByIdAsync(request.Id);
        if (dvd is not null)
            return ResultService.Fail<bool>("Dvd already exists!");

        dvd = new Domain.Entities.Read.DvdRead
        {
            Id = request.Id,
            Title = request.Title,
            Genre = request.Genre,
            Publisher = request.Publisher,
            IsAvailable = request.IsAvailable,
            Copies = request.Copies,
            CreatedAt = request.CreateAt,
            UpdatedAt = request.UpdateAt,
            DirectorId = request.DirectorId
        };

        var result = await _repository.CreateDvdAsync(dvd);

        if (result is null)
            return ResultService.Fail<bool>("Failed to create dvd!");

        return ResultService.Ok(true);


    }
}
