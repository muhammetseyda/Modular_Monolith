using Module.Inventory.Api;

namespace Module.Order.Features;

public class CreateOrderHandler
{
    public void Handle(CheckStockUseCase useCase)
    {
        Console.WriteLine("Order module only knows API contract.");
    }
}
