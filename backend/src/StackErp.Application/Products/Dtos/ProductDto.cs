namespace StackErp.Application.Products.Dtos;

public sealed record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    int MinimumStock,
    bool Active,
    DateTime CreatedAt
);