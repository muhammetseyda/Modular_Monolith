using MediatR;

namespace Modules.Order;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly OrderDbContext _context;

    public CreateOrderHandler(OrderDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}