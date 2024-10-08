using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Enums;

namespace MoviesRental.Application.Services.Dvds.Commands.UpdateDvd;
public record UpdateDvdCommand
    (
        Guid Id,
        string Title,
        int Genre,
        DateTime Published,
        Guid DirectorId,
        int Copies
    
    ) : IRequest<ResultService<UpdateDvdResponse>>;
