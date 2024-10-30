using Microsoft.EntityFrameworkCore;
using MoviesRental.Domain.Entities.Write;
using MoviesRental.Domain.Interfaces.IDirector;
using MoviesRental.Infra.Data.Context;

namespace MoviesRental.Infra.Data.Repositories.Write;
public class DirectorWriteRepository : IDirectorWriteRepository
{
    private readonly AppWriteDbContext _context;

    public DirectorWriteRepository(AppWriteDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Director?> GetDirectorWithMoviesAsync(Guid id)
    {
        return await _context.Directors
            .Include(x => x.Dvds)
            .Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();
    }

    public async Task<Director?> GetDirectorByIdAsync(Guid id)
    {
        return await _context.Directors.FindAsync(id);
    }

    public async Task<bool> CreateDirectorAsync(Director director)
    {
        _context.Directors.Add(director);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateDirectorAsync(Director director)
    {
        _context.Directors.Update(director);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteDirectorAsync(Director director)
    {
        _context.Directors.Remove(director);
        return await _context.SaveChangesAsync() > 0;
    }


}
