using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Dvds.Queries;
public record GetDvdQuery(string Tiltle) : IRequest<ResultService<GetDvdReponse>>;
