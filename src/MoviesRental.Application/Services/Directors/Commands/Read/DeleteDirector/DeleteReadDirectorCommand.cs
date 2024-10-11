using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Commands.Read.DeleteDirector;
public record DeleteReadDirectorCommand(string id) : IRequest<ResultService<bool>>;
