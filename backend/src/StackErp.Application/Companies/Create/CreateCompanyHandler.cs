using StackErp.Domain.Companies;

namespace StackErp.Application.Companies.Create;

public sealed class CreateCompanyHandler : ICreateCompanyUseCase
{
    private readonly ICompanyRepository _repository;

    public CreateCompanyHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateCompanyResult> ExecuteAsync(
        CreateCompanyCommand command,
        CancellationToken cancellationToken = default)
    {
        var documentAlreadyExists =
            await _repository.ExistsByDocumentAsync(command.Document, cancellationToken);

        if (documentAlreadyExists)
            throw new InvalidOperationException("Company with this document already exists.");

        var company = new Company(command.Name, command.Document);

        await _repository.AddAsync(company, cancellationToken);

        return new CreateCompanyResult(
            company.Id,
            company.Name,
            company.Document,
            company.Active
        );
    }
}
