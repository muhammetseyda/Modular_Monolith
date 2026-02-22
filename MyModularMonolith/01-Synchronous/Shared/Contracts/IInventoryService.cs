namespace Shared.Contracts;

public interface IInventoryService
{
    bool CheckStock(Guid productId, int quantity);
}
