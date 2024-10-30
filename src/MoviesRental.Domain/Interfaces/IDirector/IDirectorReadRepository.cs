using MoviesRental.Domain.Entities.Read;

namespace MoviesRental.Domain.Interfaces.IDirector;
public interface IDirectorReadRepository
{
    Task<DirectorRead> GetDirectorByIdAsync(string id);
    Task<DirectorRead?> GetDirectorByNameAsync(string name);
    Task<DirectorRead> CreateDirectorAsync(DirectorRead directorRead);
    Task<bool> UpdateDirectorAsync(DirectorRead directorRead);
    Task<bool> DeleteDirectorAsync(string id);
}
