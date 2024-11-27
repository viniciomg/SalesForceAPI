using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SalesForce.Infra.Context;

namespace SalesForce.Infra.Migration;

public class MigrationsContextFactory : IDesignTimeDbContextFactory<SalesForceContext>
{
    public SalesForceContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
        var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory());

        builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        builder.AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<SalesForceContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new SalesForceContext(optionsBuilder.Options);
    }
}

