using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.Write.DeleteDirector;
public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, ResultService>
{
    private readonly IDirectorWriteRepository _writeRepository;

    public DeleteDirectorCommandHandler(IDirectorWriteRepository writeRepository)
    {
        _writeRepository = writeRepository ?? throw new ArgumentNullException(nameof(writeRepository));
    }

    public async Task<ResultService> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty)
            return ResultService.Fail("Invalid id!");

        var director = await _writeRepository.GetDirectorWithMoviesAsync(request.Id);

        if (director is null)
            return ResultService.NotFound("Director not found!");

        if (director.Dvds.Any(x => x.IsAvailable))
            return ResultService.Fail("Failed to delete director!");

        var response = await _writeRepository.DeleteDirectorAsync(director);

        if (!response)
            return ResultService.Fail<bool>("Failed to delete director!");

        return ResultService.Ok("Deleted!");
    }
}
