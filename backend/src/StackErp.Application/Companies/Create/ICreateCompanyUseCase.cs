namespace StackErp.Application.Companies.Create;

public interface ICreateCompanyUseCase
{
    Task<CreateCompanyResult> ExecuteAsync(CreateCompanyCommand command);
}