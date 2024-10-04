using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.UpdateDirector;
public record UpdateDirectorCommand
    (
        Guid Id,
        string Name,
        string Surname
    
    ) : IRequest<ResultService<UpdateDirectorResponse>>;