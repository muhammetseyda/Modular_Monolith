using Microsoft.EntityFrameworkCore;

namespace Modules.Catalog;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}