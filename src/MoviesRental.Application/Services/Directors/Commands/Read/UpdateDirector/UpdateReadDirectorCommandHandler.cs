using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.Read.UpdateDirector;
public class UpdateReadDirectorCommandHandler : IRequestHandler<UpdateReadDirectorCommand, ResultService<bool>>
{
    private readonly IDirectorReadRepository _repository;

    public UpdateReadDirectorCommandHandler(IDirectorReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<bool>> Handle(UpdateReadDirectorCommand request, CancellationToken cancellationToken)
    {
        var validate = new UpdateReadDirectorCommandValidator().Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<bool>("Fields validate error!", validate);

        var readDirector = await _repository.GetDirectorByIdAsync(request.Id);

        if (readDirector is null)
            return ResultService.NotFound<bool>("Director not found!");

        readDirector.FullName = request.FullName;
        readDirector.UpdatedAt  = request.UpdateAt;

        await _repository.UpdateDirectorAsync(readDirector);

        return ResultService.Ok(true);
    }
}
