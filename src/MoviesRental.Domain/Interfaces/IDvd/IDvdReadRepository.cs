using MoviesRental.Domain.Entities.Read;

namespace MoviesRental.Domain.Interfaces.IDvd;
public interface IDvdReadRepository
{
    Task<DvdRead> GetDvdByIdAsync(string id);
    Task<DvdRead> GetDvdByTitleAsync(string title);
    Task<DvdRead> CreateDvdAsync(DvdRead dvdRead);
    Task<bool> UpdateDvdAsync(DvdRead dvdRead);
    Task<bool> DeleteDvdAsync(DvdRead dvdRead);
}
