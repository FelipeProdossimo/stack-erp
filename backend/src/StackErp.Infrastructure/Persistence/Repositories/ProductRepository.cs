using Microsoft.EntityFrameworkCore;
using StackErp.Domain.Products;

namespace StackErp.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StackErpDbContext _context;

    public ProductRepository(StackErpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);
        await Task.CompletedTask;
    }

    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .AnyAsync(p => p.Name == name, cancellationToken);
    }
}