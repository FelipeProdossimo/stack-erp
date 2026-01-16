using Microsoft.EntityFrameworkCore;
using StackErp.Domain.Companies;

namespace StackErp.Infrastructure.Persistence.Repositories;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly StackErpDbContext _context;

    public CompanyRepository(StackErpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Company company,
        CancellationToken cancellationToken = default
    )
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Company?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        return await _context.Companies
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<bool> ExistsByDocumentAsync(
        string document,
        CancellationToken cancellationToken = default
    )
    {
        return await _context.Companies
            .AnyAsync(c => c.Document == document, cancellationToken);
    }
}
