using StackErp.Domain.Entities;

namespace StackErp.Application.Companies.Interfaces;

public interface ICompanyRepository
{
    Task<Guid> CreateAsync(Company company);
    Task<Company?> GetByIdAsync(Guid id);
}