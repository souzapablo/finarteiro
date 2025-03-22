using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Features.Customers;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                dbValue => (CustomerId)Activator.CreateInstance(typeof(CustomerId), dbValue)!
            );

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()");

        builder.Property(e => e.LastUpdate)
            .HasDefaultValueSql("now()");

        builder.Property(c => c.FirstName)
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .HasMaxLength(50);

        builder.Property(c => c.Email)
            .HasMaxLength(254);

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(11);
    }
}
