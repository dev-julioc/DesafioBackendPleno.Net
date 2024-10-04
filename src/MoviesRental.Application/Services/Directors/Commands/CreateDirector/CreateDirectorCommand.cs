using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.CreateDirector;
public record CreateDirectorCommand
    (
        string Name,
        string Surname

    ) : IRequest<ResultService<CreateDirectorReponse>>;
