using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.DeleteDirector;
public record DeleteDirectorCommand(Guid Id) : IRequest<ResultService>;
