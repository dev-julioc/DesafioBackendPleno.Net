using MediatR;
using MoviesRental.Application.Services.Results;
using MoviesRental.Domain.Interfaces.IDirector;
using MoviesRental.Domain.Interfaces.IDvd;

namespace MoviesRental.Application.Services.Dvds.Commands.UpdateDvd;
public class UpdateDvdHandler : IRequestHandler<UpdateDvdCommand, ResultService<UpdateDvdResponse>>
{
    private readonly IDvdWriteRepository _dvdRepository;
    private readonly UpdateDvdCommandValidation _validator;
    private readonly IDirectorWriteRepository _directorRepository;

    public UpdateDvdHandler(IDvdWriteRepository dvdRepository, UpdateDvdCommandValidation validator, IDirectorWriteRepository directorRepository)
    {
        _dvdRepository = dvdRepository ?? throw new ArgumentNullException(nameof(dvdRepository));
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
    }

    public async Task<ResultService<UpdateDvdResponse>> Handle(UpdateDvdCommand request, CancellationToken cancellationToken)
    {
        var validate = _validator.Validate(request);

        if (!validate.IsValid)
            return ResultService.RequestError<UpdateDvdResponse>("Fields validate error!", validate);

        var dvd = await _dvdRepository.GetDvdByIdAsync(request.Id);

        if (dvd is null)
            return ResultService.NotFound<UpdateDvdResponse>("Dvd not found!");

        var director = await _directorRepository.GetDirectorByIdAsync(request.DirectorId);

        if (director is null)
            return ResultService.Fail<UpdateDvdResponse>("Director not found!");

        dvd.UpdateTitle(request.Title);
        dvd.UpdateCopies(request.Copies);
        dvd.UpdatePublisheDate(request.Published);
        dvd.UpdateGenre(request.Genre);
        dvd.UpdateDirector(request.DirectorId);

        var result = await _dvdRepository.UpdateDvdAsync(dvd);

        if (!result)
            return ResultService.Fail<UpdateDvdResponse>("Failed to update dvd!");

        var response = new UpdateDvdResponse
        (
            dvd.Id.ToString(), 
            dvd.Title, 
            dvd.Genre.ToString(), 
            dvd.Publisher, 
            dvd.Copies, 
            dvd.DirectorId.ToString(), 
            dvd.UpdatedAt
        );

        return ResultService.Ok(response);
    }
}
