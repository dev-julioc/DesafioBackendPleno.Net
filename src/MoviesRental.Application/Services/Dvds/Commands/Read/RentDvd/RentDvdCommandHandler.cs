using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.RentDvd;
public class RentDvdCommandHandler : IRequestHandler<RentDvdCommand, ResultService<bool>>
{
    private readonly IDvdReadRepository _repository;

    public RentDvdCommandHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(RentDvdCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id) || request.UpdateAt > DateTime.UtcNow)
            return ResultService.Fail<bool>("Invalid id!");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null || dvd is { Copies: 0})
            return ResultService.NotFound<bool>("Dvd not found!");

        dvd.Copies -= 1;

        var response = await _repository.UpdateDvdAsync(dvd);

        return !response
            ? ResultService.Fail<bool>("Failed to update dvd!")
            : ResultService.Ok(true);
    }
}
