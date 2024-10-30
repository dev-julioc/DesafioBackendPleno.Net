using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;

namespace MoviesRental.Application.Services.Directors.Queries;
public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, ResultService<GetDirectorResponse>>
{
    private readonly IDirectorReadRepository _repository;

    public GetDirectorQueryHandler(IDirectorReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<GetDirectorResponse>> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.FullName))
            return ResultService.Fail<GetDirectorResponse>("Field full name is required");

        var director = await _repository.GetDirectorByNameAsync(request.FullName);
        
        if(director is null)
            return ResultService.NotFound<GetDirectorResponse>("Director not found");

        var response = new GetDirectorResponse(director.Id, director.FullName);
        
        return ResultService.Ok(response);
    }
}
