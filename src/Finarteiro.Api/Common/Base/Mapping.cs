using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finarteiro.Api.Common.Base;

public abstract class Mapping<TEntity, TId> : IEntityTypeConfiguration<TEntity> 
    where TEntity : Entity<TId>
    where TId : Id, new()
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                dbValue => (TId)Activator.CreateInstance(typeof(TId), dbValue)!
            );

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("now()");

        builder.Property(e => e.LastUpdate)
            .HasDefaultValueSql("now()");

        ConfigureMapping(builder);
    }

    protected abstract void ConfigureMapping(EntityTypeBuilder<TEntity> builder);
}
