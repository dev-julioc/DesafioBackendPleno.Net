using MoviesRental.Domain.Entities.Write;

namespace MoviesRental.Domain.Interfaces.IDirector;
public interface IDirectorWriteRepository
{
    Task<bool> CreateDirectorAsync(Director director);
    Task<bool> UpdateDirectorAsync(Director director);
    Task<bool> DeleteDirectorAsync(Director director);
    Task<Director?> GetDirectorWithMoviesAsync(Guid id);
    Task<Director?> GetDirectorByIdAsync(Guid id);
}
