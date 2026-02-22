using Shared.IntegrationEvents;

namespace InventoryModule.EventHandlers;

public class OrderCreatedEventHandler
{
    public void Handle(OrderCreatedEvent @event)
    {
        Console.WriteLine("Stock decreased asynchronously.");
    }
}
