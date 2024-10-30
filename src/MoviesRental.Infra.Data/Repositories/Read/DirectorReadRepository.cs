using MongoDB.Driver;
using MoviesRental.Domain.Entities.Read;
using MoviesRental.Domain.Interfaces.IDirector;
using MoviesRental.Infra.Data.Context;

namespace MoviesRental.Infra.Data.Repositories.Read;
public class DirectorReadRepository : IDirectorReadRepository
{
    private readonly AppReadDbContext _context;

    public DirectorReadRepository(AppReadDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DirectorRead> CreateDirectorAsync(DirectorRead directorRead)
    {
        await _context.Directors.InsertOneAsync(directorRead);

        return directorRead;
    }

    public async Task<bool> DeleteDirectorAsync(string id)
    {
        var result = await _context.Directors.DeleteOneAsync(x => x.Id == id);

        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<DirectorRead> GetDirectorByIdAsync(string id)
    {
        return await _context.Directors.Find(x => x.Id.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<DirectorRead?> GetDirectorByNameAsync(string name)
    {
        return await _context.Directors.Find(x => x.FullName.ToLower().Equals(name.ToLower())).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateDirectorAsync(DirectorRead directorRead)
    {
        var result = await _context.Directors.ReplaceOneAsync(x => x.Id == directorRead.Id, directorRead);

        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}
