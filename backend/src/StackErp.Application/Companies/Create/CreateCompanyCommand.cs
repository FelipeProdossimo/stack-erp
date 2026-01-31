using MediatR;

namespace StackErp.Application.Companies.Create
{
    public sealed record CreateCompanyCommand(string Name, string Document) : IRequest<CreateCompanyResult>;
}