namespace Shared.IntegrationEvents;

public record OrderCreatedEvent(Guid ProductId, int Quantity);
