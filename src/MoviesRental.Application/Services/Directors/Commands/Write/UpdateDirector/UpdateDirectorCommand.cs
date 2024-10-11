using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.Write.UpdateDirector;
public record UpdateDirectorCommand
    (
        Guid Id,
        string Name,
        string Surname

    ) : IRequest<ResultService<UpdateDirectorResponse>>;