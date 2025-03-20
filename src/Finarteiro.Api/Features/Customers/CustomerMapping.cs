using Finarteiro.Api.Common.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Features.Customers;

public class CustomerMapping : Mapping<Customer>
{
    protected override void ConfigureMapping(EntityTypeBuilder<Customer> builder)
    {
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
