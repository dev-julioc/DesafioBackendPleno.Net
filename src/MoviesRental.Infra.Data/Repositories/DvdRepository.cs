using MoviesRental.Domain.Entities.Write;
using MoviesRental.Domain.Interfaces.IDvd;
using MoviesRental.Infra.Data.Context;

namespace MoviesRental.Infra.Data.Repositories;
public class DvdRepository : IDvdWriteRepository
{
    private readonly AppWriteDbContext _context;

    public DvdRepository(AppWriteDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Dvd?> GetDvdByIdAsync(Guid id)
    {
        return await _context.Dvds.FindAsync(id);
    }

    public async Task<bool> CreateDvdAsync(Dvd dvd)
    {
        _context.Dvds.Add(dvd);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateDvdAsync(Dvd dvd)
    {
        _context.Dvds.Update(dvd);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDvdAsync(Dvd dvd)
    {
        _context.Dvds.Remove(dvd);
        return await _context.SaveChangesAsync() > 0;
    }
}
