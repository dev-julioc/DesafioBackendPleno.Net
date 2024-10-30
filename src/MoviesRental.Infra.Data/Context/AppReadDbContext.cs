using MongoDB.Driver;
using MoviesRental.Domain.Entities.Read;
using MoviesRental.Infra.Data.Context.Settings;

namespace MoviesRental.Infra.Data.Context;
public class AppReadDbContext
{
    public IMongoCollection<DirectorRead> Directors { get; }
    public IMongoCollection<DvdRead> Dvds { get; }

    public AppReadDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);

        var database = client.GetDatabase(settings.DatabaseName);

        Directors = database.GetCollection<DirectorRead>(settings.DirectorsCollection);

        Dvds = database.GetCollection<DvdRead>(settings.DvdsCollection);

    }
}
