using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.DeleteDvd;
public class DeleteDvdCommandHandler : IRequestHandler<DeleteDvdCommand, ResultService<bool>>
{
    private readonly IDvdReadRepository _repository;

    public DeleteDvdCommandHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(DeleteDvdCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id) || request.DeleteAt > DateTime.UtcNow)
            return ResultService.Fail<bool>("Error");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<bool>("Dvd not found!");

        dvd.IsAvailable = false;
        dvd.DeletedAt = request.DeleteAt;
        dvd.Copies = 0;

        var response = await _repository.UpdateDvdAsync(dvd);

        return !response
            ? ResultService.Fail<bool>("Failed to delete dvd!")
            : ResultService.Ok(true);
    }
}
