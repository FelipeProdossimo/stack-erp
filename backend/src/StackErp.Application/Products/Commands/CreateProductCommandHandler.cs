using MediatR;
using StackErp.Application.Products.Dtos;
using StackErp.Domain.Products;

namespace StackErp.Application.Products.Commands;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductDto> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productExists = await _repository.ExistsByNameAsync(command.Name, cancellationToken);

        if (productExists)
            throw new InvalidOperationException($"Product with name '{command.Name}' already exists.");

        var product = new Product(
            command.Name,
            command.Description,
            command.Price,
            command.MinimumStock);

        await _repository.AddAsync(product, cancellationToken);

        return new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.StockQuantity,
            product.MinimumStock,
            product.Active,
            product.CreatedAt);
    }
}