using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Common.Base;

public abstract class Mapping<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()");

        builder.Property(e => e.LastUpdate)
            .HasDefaultValueSql("now()");

        ConfigureMapping(builder);
    }

    protected abstract void ConfigureMapping(EntityTypeBuilder<T> builder);
}
