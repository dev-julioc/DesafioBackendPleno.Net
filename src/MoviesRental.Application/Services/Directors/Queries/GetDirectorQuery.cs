using MediatR;
using MoviesRental.Application.Services.Results;

namespace MoviesRental.Application.Services.Directors.Queries;
public record GetDirectorQuery(string FullName) : IRequest<ResultService<GetDirectorResponse>>;
