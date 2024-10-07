using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.DeleteDvd;
public class DeleteDvdCommandHandler : IRequestHandler<DeleteDvdCommand, ResultService<DeleteDvdResponse>>
{
    private readonly IDvdWriteRepository _repository;

    public DeleteDvdCommandHandler(IDvdWriteRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<DeleteDvdResponse>> Handle(DeleteDvdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return ResultService.Fail<DeleteDvdResponse>("Invalid id!");

        var dvd = await _repository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<DeleteDvdResponse>("Dvd not found!");

        if (dvd.IsAvailable == false)
            return ResultService.Fail<DeleteDvdResponse>("Dvd already deleted!");

        dvd.DeleteDvd();

        var result = await _repository.UpdateDvdAsync(dvd);

        if (!result)
            ResultService.Fail<DeleteDvdResponse>("Failed to delete dvd!");

        var response = new DeleteDvdResponse(dvd.Id.ToString(), (DateTime)dvd.DeletedAt);

        return ResultService.Ok(response);
    }
}
