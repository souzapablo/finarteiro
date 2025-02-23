using Finarteiro.Api.Common.Base;
using Finarteiro.Api.Features.Suppliers;

namespace Finarteiro.Api.Features.Products;

public class Product : Entity
{
    private Product() { }

    public Product(string description, decimal price)
    {
        Description = description;
        Price = price;
    }

    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public long SupplierId { get; private set; }
    public Supplier Supplier { get; private set; } = null!;
}
