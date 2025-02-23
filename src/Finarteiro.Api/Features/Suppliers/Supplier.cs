using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Features.Products;

namespace Finarteiro.Api.Features.Suppliers;

public class Supplier : Entity
{
    private readonly List<Product> _products = [];

    private Supplier() { }

    public Supplier(string name, string document, string contact)
    {
        Name = name;
        Document = document;
        Contact = contact;
    }

    public string Name { get; private set; } = string.Empty;
    public string Document { get; private set; } = string.Empty;
    public string Contact { get; private set; } = string.Empty;
    public IReadOnlyCollection<Product> Products => _products;
}
