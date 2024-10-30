using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Queries;
public class GetDvdQueryHandler : IRequestHandler<GetDvdQuery, ResultService<GetDvdReponse>>
{
    private readonly IDvdReadRepository _repository;

    public GetDvdQueryHandler(IDvdReadRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<ResultService<GetDvdReponse>> Handle(GetDvdQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Tiltle))
            return ResultService.Fail<GetDvdReponse>("Invalid title!");

        var dvd = await _repository.GetDvdByTitleAsync(request.Tiltle);

        if (dvd is null)
            return ResultService.NotFound<GetDvdReponse>("Dvd not found!");

        var response = new GetDvdReponse(dvd.Id, dvd.Title, dvd.Genre, dvd.Publisher, dvd.Copies, dvd.DirectorId, dvd.CreatedAt, dvd.UpdatedAt);

        return ResultService.Ok(response);
    }
}
