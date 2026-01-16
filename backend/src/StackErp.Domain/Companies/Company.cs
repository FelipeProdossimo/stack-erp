namespace StackErp.Domain.Companies;

public sealed class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Company() { }

    public Company(string name, string document)
    {
        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }
}
