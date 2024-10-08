using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.RentDvd;
public class RentDvdHandler : IRequestHandler<RentDvdCommand, ResultService<RentDvdResponse>>
{
    private readonly IDvdWriteRepository _repository;

    public RentDvdHandler(IDvdWriteRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<RentDvdResponse>> Handle(RentDvdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return ResultService.Fail<RentDvdResponse>("Invalid id!");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<RentDvdResponse>("Dvd not found!");

        dvd.RentCopy();

        var result = await _repository.UpdateDvdAsync(dvd);

        if (!result)
            return ResultService.Fail<RentDvdResponse>("Failed to rent dvd!");

        var response = new RentDvdResponse(dvd.Id.ToString(), dvd.UpdatedAt);

        return ResultService.Ok(response);
    }
}
