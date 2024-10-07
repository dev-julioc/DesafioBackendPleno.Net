using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Commands.DeleteDvd;
public record DeleteDvdCommand(Guid Id) : IRequest<ResultService<DeleteDvdResponse>>;
