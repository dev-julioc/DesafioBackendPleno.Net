using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Write.CreateDvd;
public record CreateDvdCommand
    (
        string Title,
        int Genre,
        DateTime Published,
        int Copies,
        Guid DirectorId

    ) : IRequest<ResultService<CreateDvdResponse>>;