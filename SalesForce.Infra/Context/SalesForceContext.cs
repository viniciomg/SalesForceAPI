using Microsoft.EntityFrameworkCore;

namespace SalesForce.Infra.Context;

public  class SalesForceContext : DbContext
{
    public SalesForceContext(DbContextOptions<SalesForceContext> options) : base(options)
    {   
    }
    //  public DbSet<Client> Client { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesForceContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
