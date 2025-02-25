using Finarteiro.Api.Common.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Features.Suppliers;

public class SupplierMapping : Mapping<Supplier>
{
    protected override void ConfigureMapping(EntityTypeBuilder<Supplier> builder)
    {
        builder.Property(s => s.Name)
            .HasMaxLength(80)
            .HasColumnType("varchar");

        builder.Property(s => s.Document)
            .HasMaxLength(14)
            .HasColumnType("char")
            .IsRequired(false);

        builder.Property(s => s.Contact)
            .HasMaxLength(80)
            .HasColumnType("varchar")
            .IsRequired(false);

        builder.HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);
    }
}
