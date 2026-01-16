namespace StackErp.Domain.Companies;

public interface ICompanyRepository
{
    Task AddAsync(Company company, CancellationToken cancellationToken = default);

    Task<Company?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<bool> ExistsByDocumentAsync(
        string document,
        CancellationToken cancellationToken = default
    );
}
