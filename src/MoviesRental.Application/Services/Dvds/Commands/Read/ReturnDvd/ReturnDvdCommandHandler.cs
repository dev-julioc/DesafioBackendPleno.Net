using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.ReturnDvd;
public class ReturnDvdCommandHandler : IRequestHandler<ReturnDvdCommand, ResultService<bool>>
{
    private readonly IDvdReadRepository _repository;

    public ReturnDvdCommandHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(ReturnDvdCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id) || request.UpdatedAt > DateTime.UtcNow)
            return ResultService.Fail<bool>("Invalid id!");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<bool>("Dvd not found!");

        dvd.Copies += 1;

        var response = await _repository.UpdateDvdAsync(dvd);

        return !response
            ? ResultService.Fail<bool>("Failed to update dvd!")
            : ResultService.Ok(true);
    }
}
