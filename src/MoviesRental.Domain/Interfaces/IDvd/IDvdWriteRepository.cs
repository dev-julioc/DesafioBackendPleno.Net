using MoviesRental.Domain.Entities.Write;

namespace MoviesRental.Domain.Interfaces.IDvd;
public interface IDvdWriteRepository
{
    Task<bool> CreateDvdAsync(Dvd dvd);
    Task<bool> UpdateDvdAsync(Dvd dvd);
    Task<bool> DeleteDvdAsync(Dvd dvd);
    Task<Dvd?> GetDvdByIdAsync(Guid id);
}
