using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Infrastructure.Repositories;
using ExemploStrategy.Services;
using ExemploStrategy.Services.Contexts;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Strategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

namespace ExemploStrategy.IoC;
public static class Startup
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        services.AddScoped<ExemploStrategyContext>();

        ConfigureDatabase(configuration, services);

        var paramEnabledFakeRepository = bool.Parse(configuration.GetSection("EnabledFakeRepository").Value);

        if (paramEnabledFakeRepository)
            services.AddScoped<IFilmeRepository, FakeFilmeRepository>();
        else
            services.AddScoped<IFilmeRepository, FilmeRepository>();

        services.AddScoped<IFilmeService, FilmeService>();

        ConfigureStrategies(services);
    }

    private static void ConfigureDatabase(IConfiguration configuration, IServiceCollection services)
    {
        var connStr = configuration.GetConnectionString("filmeDb");

        services.AddScoped<IDbConnection>(provider => new MySqlConnection(connStr));
    }
    private static void ConfigureStrategies(IServiceCollection services)
    {
        services.AddScoped<GetAllFilmeStrategy>();
        services.AddScoped<GetFilmeByIdStrategy>();
        services.AddScoped<CreateFilmeStrategy>();
        services.AddScoped<UpdateFilmeStrategy>();
        services.AddScoped<DeleteFilmeStrategy>();

        services.AddScoped((provider) =>
        {
            return new Dictionary<Type, IExemploStrategy>
            {
                { typeof(GetAllFilmeRequest), provider.GetService<GetAllFilmeStrategy>() },
                { typeof(GetFilmeByIdRequest), provider.GetService<GetFilmeByIdStrategy>() },
                { typeof(CreateFilmeRequest), provider.GetService<CreateFilmeStrategy>() },
                { typeof(UpdateFilmeRequest), provider.GetService<UpdateFilmeStrategy>() },
                { typeof(DeleteFilmeRequest), provider.GetService<DeleteFilmeStrategy>() }
            };
        });
    }
}
