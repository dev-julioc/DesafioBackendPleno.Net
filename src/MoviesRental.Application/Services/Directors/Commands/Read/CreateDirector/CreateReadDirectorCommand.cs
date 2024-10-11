using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.Read.CreateDirector;
public record CreateReadDirectorCommand
    (
        string Id,
        string FullName,
        DateTime CreateAt,
        DateTime UpdateAt

    ) : IRequest<ResultService<bool>>;
