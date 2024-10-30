using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.Read.DeleteDirector;
public class DeleteReadDirectorCommandHandler : IRequestHandler<DeleteReadDirectorCommand, ResultService<bool>>
{
    private readonly IDirectorReadRepository _repository;

    public DeleteReadDirectorCommandHandler(IDirectorReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(DeleteReadDirectorCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.id))
            return ResultService.Fail<bool>("Invalid id!");

        var director = await _repository.GetDirectorByIdAsync(request.id);

        if (director is null)
            return ResultService.NotFound<bool>("Director not found!");

        var response = await _repository.DeleteDirectorAsync(request.id);

        if (!response)
            return ResultService.Fail<bool>("Failed to delete director!");

        return ResultService.Ok(true);
    }
}
