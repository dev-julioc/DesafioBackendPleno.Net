using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.DeleteDvd;
public record DeleteDvdCommand
(
    string Id,
    DateTime DeleteAt

) : IRequest<ResultService<bool>>;


