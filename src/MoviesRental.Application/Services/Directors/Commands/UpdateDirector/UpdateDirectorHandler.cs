using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Commands.UpdateDirector;
public class UpdateDirectorHandler : IRequestHandler<UpdateDirectorCommand, ResultService<UpdateDirectorResponse>>
{
    private readonly IDirectorWriteRepository _repository;
    private readonly UpdateDirectorValidation _validator;

    public UpdateDirectorHandler(IDirectorWriteRepository repository, UpdateDirectorValidation validator)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<ResultService<UpdateDirectorResponse>> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
    {
        var validate = _validator.Validate(request);

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
