using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.ReturnDvd;
public class ReturnDvdHandler : IRequestHandler<ReturnDvdCommand, ResultService<ReturnDvdResponse>>
{
    private readonly IDvdWriteRepository _repository;

    public ReturnDvdHandler(IDvdWriteRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<ReturnDvdResponse>> Handle(ReturnDvdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return ResultService.Fail<ReturnDvdResponse>("Invalid id!");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<ReturnDvdResponse>("Dvd not found!");

        dvd.ReturnCopy();

        var result = await _repository.UpdateDvdAsync(dvd);

        if (!result)
            return ResultService.Fail<ReturnDvdResponse>("Failed to return dvd!");

        var response = new ReturnDvdResponse(dvd.Id.ToString(), dvd.UpdatedAt);

        return ResultService.Ok(response);
    }
}
