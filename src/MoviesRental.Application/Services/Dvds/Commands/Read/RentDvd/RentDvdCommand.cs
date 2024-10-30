using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Read.RentDvd;
public record RentDvdCommand
(
    string Id,
    DateTime UpdateAt

) : IRequest<ResultService<bool>>;
