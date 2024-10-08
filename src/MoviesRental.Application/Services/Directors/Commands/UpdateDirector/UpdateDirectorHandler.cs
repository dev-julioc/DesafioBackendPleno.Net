using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.UpdateDirector;
public class UpdateDirectorHandler : IRequestHandler<UpdateDirectorCommand, ResultService<UpdateDirectorResponse>>
{
    private readonly IDirectorWriteRepository _repository;

    public UpdateDirectorHandler(IDirectorWriteRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<UpdateDirectorResponse>> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var validate = new UpdateDirectorValidation().Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<UpdateDirectorResponse>("Fields validate error!", validate);

        var director = await _repository.GetDirectorByIdAsync(request.Id);

        director.UpdateName(request.Name);
        director.UpdateSurName(director.Name);

        var result = await _repository.UpdateDirectorAsync(director);

        if (!result)
            return ResultService.Fail<UpdateDirectorResponse>("Failed to update director!");

        var response = new UpdateDirectorResponse(director.Id.ToString(), director.FullName(), director.UpdatedAt);

        return ResultService.Ok(response);
    }
}
