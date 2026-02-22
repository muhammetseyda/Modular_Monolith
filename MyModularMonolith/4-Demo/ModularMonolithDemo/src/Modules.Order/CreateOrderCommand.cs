using MediatR;

namespace Modules.Order;

public record CreateOrderCommand(Guid ProductId, int Quantity) : IRequest<Guid>;