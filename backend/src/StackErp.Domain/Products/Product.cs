namespace StackErp.Domain.Products;

public sealed class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }
    public int MinimumStock { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal price, int minimumStock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = 0;
        MinimumStock = minimumStock;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string name, string description, decimal price, int minimumStock)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));

        Name = name;
        Description = description;
        Price = price;
        MinimumStock = minimumStock;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AdjustStock(int quantity)
    {
        if (StockQuantity + quantity < 0)
            throw new InvalidOperationException("Insufficient stock");

        StockQuantity += quantity;
    }

    public void Deactivate()
    {
        Active = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        Active = true;
        UpdatedAt = DateTime.UtcNow;
    }
}