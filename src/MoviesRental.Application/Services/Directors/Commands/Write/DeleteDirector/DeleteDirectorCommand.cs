using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.Write.DeleteDirector;
public record DeleteDirectorCommand(Guid Id) : IRequest<ResultService>;
