using Shared.IntegrationEvents;

namespace OrderModule.Features;

public class CreateOrderHandler
{
    public OrderCreatedEvent Handle(Guid productId, int quantity)
    {
        Console.WriteLine("Order created.");
        return new OrderCreatedEvent(productId, quantity);
    }
}
