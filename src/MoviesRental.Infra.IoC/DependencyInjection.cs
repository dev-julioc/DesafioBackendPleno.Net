using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesRental.Application.Services.Dvds.Commands.CreateDvd;
using System;
using System.Reflection;

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
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateDvdCommand).Assembly));

        return services;
    }

}
