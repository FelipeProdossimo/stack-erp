using MediatR;
using StackErp.Application.Products.Dtos;

namespace StackErp.Application.Products.Commands;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int MinimumStock
) : IRequest<ProductDto>;