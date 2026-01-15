using StackErp.Domain.Companies;

namespace StackErp.Application.Companies;

public interface ICompanyRepository
{
    Task CreateAsync(Company company, CancellationToken cancellationToken);
    Task<bool> ExistsByDocumentAsync(string document, CancellationToken cancellationToken);
}
