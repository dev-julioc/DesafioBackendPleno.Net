using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.UpdateDvd;
public record UpdateDvdCommand
(
    string Id,
    string Title,
    string Genre,
    DateTime Publisher,
    int Copies,
    string DirectorId,
    DateTime UpdatedAt

) : IRequest<ResultService<bool>>;
