using Shared.Contracts;

namespace OrderModule.Features;

public class CreateOrderHandler
{
    private readonly IInventoryService _inventoryService;

    public CreateOrderHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public void Handle(Guid productId, int quantity)
    {
        if(!_inventoryService.CheckStock(productId, quantity))
            throw new Exception("Out of stock");

        Console.WriteLine("Order created.");
    }
}
