using StackErp.Application.Companies.Create;

namespace StackErp.Api.Endpoints.Companies;

public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this WebApplication app)
    {
        app.MapPost("/companies", async (
            CreateCompanyCommand command,
            ICreateCompanyUseCase useCase,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await useCase.ExecuteAsync(command, cancellationToken);

            return Results.Created($"/companies/{result.Id}", result);
        });
    }
}