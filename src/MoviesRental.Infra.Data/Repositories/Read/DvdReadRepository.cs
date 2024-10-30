using MongoDB.Driver;
using MoviesRental.Domain.Entities.Read;
using MoviesRental.Domain.Interfaces.IDvd;
using MoviesRental.Infra.Data.Context;

namespace MoviesRental.Infra.Data.Repositories.Read;
public class DvdReadRepository : IDvdReadRepository
{
    private readonly AppReadDbContext _context;

    public DvdReadRepository(AppReadDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DvdRead> CreateDvdAsync(DvdRead dvdRead)
    {
        await _context.Dvds.InsertOneAsync(dvdRead);

        return dvdRead;
    }

    public async Task<bool> DeleteDvdAsync(DvdRead dvdRead)
    {
        var result = await _context.Dvds.DeleteOneAsync(x => x.Id == dvdRead.Id);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<DvdRead> GetDvdByIdAsync(string id)
    {
        return await _context.Dvds.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<DvdRead> GetDvdByTitleAsync(string title)
    {
        return await _context.Dvds.Find(x => x.Title.ToLower().Equals(title.ToLower())).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateDvdAsync(DvdRead dvdRead)
    {
        var result = await _context.Dvds.ReplaceOneAsync(x => x.Id == dvdRead.Id, dvdRead);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}
