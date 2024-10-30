using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.CreateDvd;
public record CreateDvdCommand
(
    string Id,
    string Title,
    string Genre,
    DateTime Publisher,
    bool IsAvailable,
    int Copies,
    string DirectorId,
    DateTime CreateAt,
    DateTime UpdateAt

) : IRequest<ResultService<bool>>;
    

