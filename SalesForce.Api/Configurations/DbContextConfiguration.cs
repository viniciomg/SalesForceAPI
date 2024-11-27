using Microsoft.EntityFrameworkCore;
using SalesForce.Infra.Context;


namespace SalesForce.Api.Configurations;
public static class DbContextConfiguration
{
    public static IServiceCollection AddPostgreeSqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SalesForceContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Transient);

        return services;
    }
}
