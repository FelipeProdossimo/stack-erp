using Microsoft.EntityFrameworkCore;
using StackErp.Domain.Companies;
using StackErp.Domain.Products;

namespace StackErp.Infrastructure.Persistence;

public class StackErpDbContext : DbContext
{
    public StackErpDbContext(DbContextOptions<StackErpDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StackErpDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
