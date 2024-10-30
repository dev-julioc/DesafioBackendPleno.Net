using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.ReturnDvd;
public record ReturnDvdCommand
(
    string Id,
    DateTime UpdatedAt

) : IRequest<ResultService<bool>>;
