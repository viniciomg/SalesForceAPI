using Microsoft.Extensions.DependencyInjection;
using SalesForce.Domain.Interfaces.Repository;
using SalesForce.Infra.Repositories;

namespace SalesForce.Infra;

public static class RegisterRepositoryInstances
{
    public static IServiceCollection AddRegisterRepository(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        return services;
    }
}
