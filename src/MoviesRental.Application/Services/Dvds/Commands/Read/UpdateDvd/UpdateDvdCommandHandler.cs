using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.UpdateDvd;
public class UpdateDvdCommandHandler : IRequestHandler<UpdateDvdCommand, ResultService<bool>>
{
    private readonly IDvdReadRepository _repository;

    public UpdateDvdCommandHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(UpdateDvdCommand request, CancellationToken cancellationToken)
    {
        var validate = new UpdateDvdCommandValidator().Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<bool>("Fields validate error!", validate);

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<bool>("Dvd not found!");

        dvd.Title = request.Title;
        dvd.Genre = request.Genre;
        dvd.Publisher = request.Publisher;
        dvd.Copies = request.Copies;
        dvd.DirectorId = request.DirectorId;
        dvd.UpdatedAt = request.UpdatedAt;

        var response = await _repository.UpdateDvdAsync(dvd);

        return !response
            ? ResultService.Fail<bool>("Failed to update dvd!")
            : ResultService.Ok(true);
    }
}
