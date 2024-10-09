using Microsoft.EntityFrameworkCore;
using MoviesRental.Domain.Entities.Write;
using System;

namespace MoviesRental.Infra.Data.Context;
public class AppWriteDbContext : DbContext
{
    public AppWriteDbContext(DbContextOptions<AppWriteDbContext> options) : base(options)
    { }

    public DbSet<Director> Directors { get; set; }
    public DbSet<Dvd> Dvds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppWriteDbContext).Assembly);
    }
}
