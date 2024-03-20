using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Infrastructure.Repositories;
using ExemploStrategy.Services;
using ExemploStrategy.Services.Contexts;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Strategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploStrategy.IoC;
public static class Startup
{
    public static void Configure(IConfiguration configuration, IServiceCollection services)
    {
        services.AddSingleton<ExemploStrategyContext>();

        services.AddSingleton<IFilmeRepository, FakeFilmeRepository>();
        services.AddSingleton<IFilmeService, FilmeService>();

        services.AddSingleton<GetAllFilmeStrategy>();
        services.AddSingleton<GetFilmeByIdStrategy>();
        services.AddSingleton<CreateFilmeStrategy>();
        services.AddSingleton<UpdateFilmeStrategy>();
        services.AddSingleton<DeleteFilmeStrategy>();

        services.AddSingleton((provider) =>
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
