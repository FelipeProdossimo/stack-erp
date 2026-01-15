using StackErp.Domain.Companies;

namespace StackErp.Application.Companies.Create;

public sealed class CreateCompanyHandler
{
    private readonly ICompanyRepository _repository;

    public CreateCompanyHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateCompanyResult> Handle(
        CreateCompanyCommand command,
        CancellationToken cancellationToken)
    {
        var documentAlreadyExists =
            await _repository.ExistsByDocumentAsync(command.Document, cancellationToken);

        if (documentAlreadyExists)
            throw new InvalidOperationException("Company with this document already exists.");

        var company = new Company(command.Name, command.Document);

        await _repository.CreateAsync(company, cancellationToken);

        return new CreateCompanyResult(
            company.Id,
            company.Name,
            company.Document,
            company.Active
        );
    }
}
