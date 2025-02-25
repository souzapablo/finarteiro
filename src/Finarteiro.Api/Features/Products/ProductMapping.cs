using Finarteiro.Api.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Features.Products;

public class ProductMapping : Mapping<Product>
{
    protected override void ConfigureMapping(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Description)
            .HasMaxLength(80)
            .HasColumnType("varchar");

        builder.Property(p => p.Price)
            .HasPrecision(18, 4)
            .HasColumnType("numeric");
    }
}
