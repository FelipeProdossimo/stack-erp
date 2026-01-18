namespace StackErp.Application.Companies.Create;

public sealed record CreateCompanyResult(
    Guid Id,
    string Name,
    string Document,
    bool Active//,
    //DateTime CreatedAt
);