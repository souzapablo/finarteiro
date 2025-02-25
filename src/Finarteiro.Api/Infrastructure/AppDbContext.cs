using Finarteiro.Api.Features.Products;
using Finarteiro.Api.Features.Suppliers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Finarteiro.Api.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Supplier> Suppliers { get; private set; }
    public DbSet<Product> Products { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
