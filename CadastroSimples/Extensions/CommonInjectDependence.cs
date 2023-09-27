using CadastroSimples.Data.Repositories;
using CadastroSimples.Domain.Interfaces.Repository;
using CadastroSimples.Domain.Interfaces.Service;
using CadastroSimples.Services;

namespace CadastroSimples.Extensions;

public static class CommonInjectDependence
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IClientService, ClientService>();
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IClientRepository, ClientRepository>();
        return services;
    }
}
