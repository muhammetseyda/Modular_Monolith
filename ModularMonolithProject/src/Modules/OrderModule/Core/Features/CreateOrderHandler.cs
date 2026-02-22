using Shared.Contracts; // Sadece sözleşmeyi (Interface) referans alır

namespace OrderModule.Core.Features;

internal sealed class CreateOrderHandler 
{
    private readonly IInventoryService _inventoryService;
    private readonly OrderDbContext _dbContext;

    // Dependency Injection, Host ayağa kalktığında bunu otomatik çözecek
    public CreateOrderHandler(IInventoryService inventoryService, OrderDbContext dbContext)
    {
        _inventoryService = inventoryService;
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // 1. Diğer modülle SENKRON iletişim (Hızlı ve doğrudan)
        var hasStock = await _inventoryService.CheckStockAvailabilityAsync(request.ProductId, request.Quantity);

        if (!hasStock)
            return false;

        // 2. Kendi modülünün veritabanı işlemi
        var order = new Order { ProductId = request.ProductId, Quantity = request.Quantity, OrderDate = DateTime.UtcNow };
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}