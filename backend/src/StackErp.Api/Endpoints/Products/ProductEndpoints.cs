using MediatR;
using StackErp.Application.Products.Commands;
using StackErp.Application.Products.Dtos;

namespace StackErp.Api.Endpoints.Products;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var products = app.MapGroup("/products")
            .WithTags("Products");

        // POST /products
        products.MapPost("/", async (
            CreateProductCommand command,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return Results.Created($"/products/{result.Id}", result);
        })
        .WithName("CreateProduct")
        .Produces<ProductDto>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest);

        // GET /products
        products.MapGet("/", () =>
        {
            return Results.Ok(new
            {
                message = "Products endpoint is ready!",
                endpoints = new[]
                {
                    "POST /products - Create a new product",
                    "GET /products - List all products (coming soon)"
                }
            });
        })
        .WithName("GetProducts")
        .Produces(StatusCodes.Status200OK);
    }
}