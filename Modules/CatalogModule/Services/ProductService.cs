namespace CatalogModule.Services;

// Sadece basit CRUD işlemleri yapan standart bir servis
internal sealed class ProductService : IProductService
{
    private readonly CatalogDbContext _dbContext;

    public ProductService(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductDto> GetProductAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return new ProductDto(product.Id, product.Name, product.Price);
    }

    public async Task CreateProductAsync(CreateProductDto request)
    {
        _dbContext.Products.Add(new Product { Name = request.Name, Price = request.Price });
        await _dbContext.SaveChangesAsync();
    }
}