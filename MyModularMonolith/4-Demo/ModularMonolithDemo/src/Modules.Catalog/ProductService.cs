using Microsoft.EntityFrameworkCore;

namespace Modules.Catalog;

public class ProductService
{
    private readonly CatalogDbContext _context;

    public ProductService(CatalogDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
        => await _context.Products.ToListAsync();

    public async Task AddAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}