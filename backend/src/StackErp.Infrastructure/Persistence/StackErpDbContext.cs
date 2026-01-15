using Microsoft.EntityFrameworkCore;
using StackErp.Domain.Companies;

namespace StackErp.Infrastructure.Persistence;

public class StackErpDbContext : DbContext
{
    public StackErpDbContext(DbContextOptions<StackErpDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StackErpDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
