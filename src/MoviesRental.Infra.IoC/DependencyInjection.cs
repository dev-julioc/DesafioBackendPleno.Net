using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesRental.Application.Services.Dvds.Commands.CreateDvd;
using MoviesRental.Domain.Interfaces.IDirector;
using MoviesRental.Domain.Interfaces.IDvd;
using MoviesRental.Infra.Data.Repositories;

namespace MoviesRental.Infra.IoC;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("PostgressConexao");
        //var connectionStringBuilder = new NpgsqlConnectionStringBuilder(connectionString);
        //var searchPaths = connectionStringBuilder.SearchPath?.Split(',');

        //services.AddDbContext<AppDbContext>(options =>
        //{
        //    options.UseNpgsql(connectionString, b =>

        //    {
        //        b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);

        //        if (searchPaths is { Length: > 0 })
        //        {
        //            var mainSchema = searchPaths[0];
        //            b.MigrationsHistoryTable(HistoryRepository.DefaultTableName, mainSchema);
        //        }
        //    });
        //});
        services.AddScoped<IDirectorWriteRepository, DirectorWriteRepository>();
        services.AddScoped<IDvdWriteRepository, DvdWriteRepository>();

        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDvdCommand).Assembly));

        return services;
    }

}
