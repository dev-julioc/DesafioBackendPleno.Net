using MoviesRental.Domain.Entities.Read;

namespace MoviesRental.Domain.Interfaces.IDirector;
public interface IDirectorReadRepository
{
    Task<List<DirectorRead>> GetAllDirectorsAsync();
    Task<DirectorRead> GetDirectorByIdAsync(Guid id);
}
