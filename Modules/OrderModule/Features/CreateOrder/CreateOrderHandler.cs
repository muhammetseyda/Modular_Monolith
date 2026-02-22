using MediatR; // Veya kullandığınız başka bir dispatcher

namespace OrderModule.Features.CreateOrder;

// Sadece sipariş oluşturma işleminin Command'ı
public record CreateOrderCommand(int ProductId, int Quantity, string UserId) : IRequest<bool>;

// Sadece sipariş oluşturma işleminin Handler'ı (İş Mantığı)
internal sealed class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
{
    private readonly OrderDbContext _dbContext;
    // Özel repository'ler, event publisher'lar buraya inject edilir.

    public CreateOrderHandler(OrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // 1. İş kuralları (Validation, Stok kontrolü vs.)
        // 2. Siparişin veritabanına yazılması
        var order = new Order(request.ProductId, request.Quantity, request.UserId);
        _dbContext.Orders.Add(order);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}