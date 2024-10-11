using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.Read.UpdateDirector;
public record UpdateReadDirectorCommand
    (
        string Id,
        string FullName,
        DateTime UpdateAt
 
    ) : IRequest<ResultService<bool>>;
