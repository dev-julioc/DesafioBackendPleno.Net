using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.Write.ReturnDvd;
public record ReturnDvdCommand(Guid Id) : IRequest<ResultService<ReturnDvdResponse>>;