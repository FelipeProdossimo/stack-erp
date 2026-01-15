namespace StackErp.Domain.Companies;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected Company() { } // necessário para ORMs futuramente

    public Company(string name, string document)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(CompanyErrors.NameRequired);

        if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException(CompanyErrors.DocumentRequired);

        Id = Guid.NewGuid();
        Name = name.Trim();
        Document = document.Trim();
        Active = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Activate()
    {
        Active = true;
    }
}
