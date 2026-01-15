using StackErp.Domain.Common;

namespace StackErp.Domain.Entities;

public class Company : Entity
{
    public string Name { get; private set; }
    public string Document { get; private set; }
    public bool Active { get; private set; }

    protected Company() { }

    public Company(string name, string document)
    {
        Name = name;
        Document = document;
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }
}