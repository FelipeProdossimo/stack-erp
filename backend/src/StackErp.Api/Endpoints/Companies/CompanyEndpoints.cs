using MediatR;
using StackErp.Application.Companies.Create;

namespace StackErp.Api.Endpoints.Companies;

public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/companies")
            .WithTags("Companies");

        group.MapPost("/", async (
            CreateCompanyCommand command,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return Results.Created($"/companies/{result.Id}", result);
        })
        .WithName("CreateCompany")
        .Produces<CreateCompanyResult>(201)
        .ProducesProblem(400);

        group.MapGet("/", () =>
        {
            return Results.Ok(new { message = "Companies endpoint is working!" });
        })
        .WithName("GetCompanies")
        .Produces(200);
    }
}